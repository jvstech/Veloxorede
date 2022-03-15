using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veloxorede
{
  public partial class MainForm : Form
  {
    private List<TextLocation> textLocations_ = new List<TextLocation>();
    private PauseTokenSource pauseTokenSource_ = new PauseTokenSource();
    private CancellationTokenSource cancelTokenSource_;
    private Task readingTask_;

    public MainForm()
    {
      InitializeComponent();
    }

    private async Task ParseInputText()
    {
      scrollingText.SuspendLayout();
      ClearScrollingText();
      if (toggleTextToSpeechButton.Checked)
      {
        textLocations_ = await Program.ParseSentencesAsync(inputText.Text);
      }
      else
      {
        textLocations_ = (await Program.ParseAsync(inputText.Text,
          word => AddScrollingWord(word),
          space => AddScrollingSpace(space)))
          .Where(l => l.Type == TextType.Word)
          .OrderBy(l => l.Start)
          .ToList();
      }

      scrollingText.ResumeLayout();
    }

    private void inputText_TextChanged(object sender, EventArgs e)
    {
      //ParseInputText();
    }

    private void AddScrollingSpace(string space)
    {
      var addSpaceAction = new Action(() =>
      {
        int selectStart = scrollingText.TextLength;
        scrollingText.AppendText(space);
        int selectLen = scrollingText.TextLength - selectStart;
        scrollingText.SelectionStart = selectStart;
        scrollingText.SelectionLength = selectLen;
        scrollingText.SelectionColor = Program.TextColor;
        scrollingText.SelectionBackColor = scrollingText.BackColor;
      });
      
      if (scrollingText.InvokeRequired)
      {
        scrollingText.Invoke(addSpaceAction);
      }
      else
      {
        addSpaceAction();
      }
    }

    private void AddScrollingWord(string word)
    {
      var addWordAction = new Action(() =>
      {
        int selectStart = scrollingText.TextLength;
        scrollingText.AppendText(word);
        int selectLen = scrollingText.TextLength - selectStart;
        scrollingText.SelectionStart = selectStart;
        scrollingText.SelectionLength = selectLen;
        scrollingText.SelectionColor = Program.HiddenColor;
        scrollingText.SelectionBackColor = Program.HiddenColor;
      });

      if (scrollingText.InvokeRequired)
      {
        scrollingText.Invoke(addWordAction);
      }
      else
      {
        addWordAction();
      }
    }

    private void ClearScrollingText()
    {
      scrollingText.SelectAll();
      scrollingText.SelectionColor = Color.Black;
      scrollingText.SelectionBackColor = scrollingText.BackColor;
      scrollingText.Clear();
    }

    private void ShowScrollingWord(int idx)
    {
      var textLocation = textLocations_[idx];
      scrollingText.SelectionStart = textLocation.Start;
      scrollingText.SelectionLength = textLocation.Length;
      scrollingText.SelectionBackColor = scrollingText.BackColor;
      scrollingText.SelectionColor = Program.TextColor;
      scrollingText.SelectionStart = textLocation.End;
      var textLine = scrollingText.GetLineFromCharIndex(textLocation.Start) + 1;
      var visibleLines = scrollingText.GetVisibleLineCount();
      var visibleLine = textLine % visibleLines;
      if (visibleLine >= visibleLines / 4)
      {
        var scrollIndex = scrollingText.GetFirstCharIndexFromLine(
          textLine + (visibleLines / 2));
        if (scrollIndex < 0)
        {
          scrollingText.ScrollToBottom();
        }
        else
        {
          scrollingText.Select(scrollIndex, 0);
          scrollingText.ScrollToSelectionStart();
          scrollingText.SelectionLength = 0;
        }
      }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      Program.SetLineSpacing(scrollingText, LineSpacingRule.OneAndAHalf);
    }

    private async void MainForm_FormClosing(object sender,
      FormClosingEventArgs e)
    {
      await this.PerformStop();
    }

    private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      (intervalValue.NumericUpDownControl as NumericUpDown).DownButton();
    }

    private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      (intervalValue.NumericUpDownControl as NumericUpDown).UpButton();
    }

    private void intervalValue_ValueChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.Interval = intervalValue.Value;
      Properties.Settings.Default.Save();
    }

    private void groupSizeValue_ValueChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.GroupSize = groupSizeValue.Value;
      Properties.Settings.Default.Save();
    }

    private async Task StartScrolling(bool includeTextToSpeech,
      CancellationToken cancelToken, PauseToken pauseToken)
    {
      Func<int, int> getLineNumber = (n) =>
        scrollingText.GetLineFromCharIndex(textLocations_[n].Start);

      await this.PrepareToStart();

      int lastIdx = this.textLocations_.Count - 1;
      StringBuilder voiceBuffer = null;
      using (var tts = new SpeechSynthesizer())
      {
        if (includeTextToSpeech)
        {
          tts.SetOutputToDefaultAudioDevice();
          tts.Rate = -(Program.IntegerLerp((int)intervalValue.Value,
            (int)intervalValue.Minimum, (int)intervalValue.Maximum,
            -10, 10));
          voiceBuffer = new StringBuilder();
        }

        for (int idx = 0; idx <= lastIdx; idx++)
        {
          this.ShowScrollingWord(idx);
          if (idx >= lastIdx)
          {
            break;
          }

          if (includeTextToSpeech)
          {
            string sentence = textLocations_[idx].GetText(inputText.Text);
            sentence = Regex.Replace(sentence, @"[\r\n]+", " ");
            sentence = Regex.Replace(sentence, @" {2,}", " ");
            voiceBuffer.Append(sentence);
            Debug.WriteLine(voiceBuffer.ToString());
          }

          if (!includeTextToSpeech)
          {
            if (idx % (int)this.groupSizeValue.Value == 0 ||
              // Don't unmask text across line boundaries
              (idx < lastIdx &&
              getLineNumber(idx + 1) != getLineNumber(idx)))
            {
              int delay = (int)this.intervalValue.Value;
              if (cancelToken.IsCancellationRequested)
              {
                break;
              }

              await pauseToken.WaitWhilePausedAsync();
              await Task.Delay(delay);
            }
          }
          else
          {
            await Task.Run(() => tts.Speak(voiceBuffer.ToString()), 
              cancelToken);
            voiceBuffer.Clear();
            if (cancelToken.IsCancellationRequested)
            {
              break;
            }

            await pauseToken.WaitWhilePausedAsync();
          }
        }
      }

      this.PrepareForStop();
    }

    private void ToggleControls()
    {
      Program.ToggleControls(inputText, pauseButton,
        pauseContinueToolStripMenuItem, openToolStripMenuItem);
    }

    private async Task PrepareToStart()
    {
      ToggleControls();
      this.startStopButton.Image = Properties.Resources.stop_16;
      await ParseInputText();
    }

    private void PrepareForStop()
    {
      this.startStopButton.Image = Properties.Resources.play_6_16;
      ToggleControls();
      this.pauseTokenSource_ = new PauseTokenSource();
      this.cancelTokenSource_ = null;
    }

    private async void startStopButton_Click(object sender, EventArgs e)
    {
      if (await PerformStop())
      {
        return;
      }

      var pauseToken = this.pauseTokenSource_.Token;
      this.cancelTokenSource_ = new CancellationTokenSource();
      readingTask_ = this.StartScrolling(toggleTextToSpeechButton.Checked,
        this.cancelTokenSource_.Token, pauseToken);
      await readingTask_;
      readingTask_ = null;
    }

    private async Task<bool> PerformStop()
    {
      if (this.cancelTokenSource_ != null && readingTask_ != null)
      {
        this.cancelTokenSource_.Cancel();
        this.pauseTokenSource_.IsPaused = false;
        this.statusLabel.Text = "";
        await readingTask_;
        return true;
      }

      return false;
    }

    private void pauseButton_Click(object sender, EventArgs e)
    {
      this.pauseTokenSource_.IsPaused = !this.pauseTokenSource_.IsPaused;
      this.statusLabel.Text = this.pauseTokenSource_.IsPaused ? "Paused" : "";
    }

    private void pauseContinueToolStripMenuItem_Click(object sender, 
      EventArgs e)
    {
      pauseButton.PerformClick();
    }

    private void increaseGroupSizeToolStripMenuItem_Click(object sender, 
      EventArgs e)
    {
      (groupSizeValue.NumericUpDownControl as NumericUpDown).UpButton();
    }

    private void decreaseGroupSizeToolStripMenuItem_Click(object sender, 
      EventArgs e)
    {
      (groupSizeValue.NumericUpDownControl as NumericUpDown).DownButton();
    }

    private void importFromClipboardToolStripMenuItem_Click(object sender, 
      EventArgs e)
    {
      //var extAsciiEncoding = Encoding.GetEncoding("windows-1252");
      var input = Clipboard.GetText(TextDataFormat.Text);
      input = Regex.Replace(input, "\u201c|\u201d", "\"");
      input = Regex.Replace(input, "(\u2014)", " $1 ");
      inputText.Text = input;
    }
  }
}
