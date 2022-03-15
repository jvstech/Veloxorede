using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veloxorede
{
  static class Program
  {
    public static Color HiddenColor { get; internal set; } = Color.Gray;
    public static Color TextColor { get; internal set; } = Color.Black;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
      Properties.Settings.Default.Save();
    }

    public static async Task<List<TextLocation>> ParseAsync(string text, 
      Action<string> onWordParsed = null,
      Action<string> onSpaceParsed = null)
    {
      List<TextLocation> locations = new List<TextLocation>();
      if (string.IsNullOrEmpty(text))
      {
        return locations;
      }

      int nextSpaceIdx = 0;

      await Task.Run(() =>
      {
        var m = Regex.Match(text, @"[^\s\r\n]+");
        while (m.Success)
        {
          if (m.Index > nextSpaceIdx)
          {
            onSpaceParsed?.Invoke(text.Substring(nextSpaceIdx, 
              (m.Index - nextSpaceIdx)));
            locations.Add(new TextLocation(nextSpaceIdx, 
              (m.Index - nextSpaceIdx), TextType.Space));
          }

          onWordParsed?.Invoke(m.Value);
          locations.Add(new TextLocation(m.Index, m.Length, TextType.Word));
          nextSpaceIdx = m.Index + m.Length;
          m = m.NextMatch();
        }
      });

      return locations;
    }

    public static async Task<List<TextLocation>> ParseSentencesAsync(
      string text)
    {
      var locations = new List<TextLocation>();
      if (string.IsNullOrWhiteSpace(text))
      {
        return locations;
      }

      await Task.Run(() =>
      {
        int lastIdx = 0;
        var m = Regex.Match(text, 
          @"(?<=[\.!\?][\u201c\x22]?)[\s\u201d\x22]+");
        while (m.Success)
        {
          if (m.Index - lastIdx > 0)
          {
            locations.Add(new TextLocation(lastIdx, m.Index - lastIdx,
              TextType.Word));            
          }

          lastIdx = m.Index;
          m = m.NextMatch();
        }
      });

      return locations;
    }

    public static void SetLineSpacing(TextBoxBase textBox, LineSpacingRule rule,
      int? spacing = null)
    {
      Native.PARAFORMAT fmt = new Native.PARAFORMAT();
      fmt.cbSize = Marshal.SizeOf(fmt);
      textBox.SelectAll();
      Native.SendMessage(textBox.Handle, Native.EM_GETPARAFORMAT, 0, ref fmt);
      if (spacing == null)
      {
        spacing = fmt.dyLineSpacing;
      }

      fmt.cbSize = Marshal.SizeOf(fmt);
      fmt.dwMask = Native.PFM_LINESPACING;
      fmt.dyLineSpacing = spacing.Value;
      fmt.bLineSpacingRule = (byte)rule;
      textBox.SelectAll();
      Native.SendMessage(textBox.Handle, Native.EM_SETPARAFORMAT, 0, ref fmt);
    }

    public static void ToggleControls(params object[] controls)
    {
      foreach (Control ctrl in controls.OfType<Control>())
      {
        ctrl.Enabled = !ctrl.Enabled;
      }

      foreach (ToolStripItem ctrl in controls.OfType<ToolStripItem>())
      {
        ctrl.Enabled = !ctrl.Enabled;
      }
    }

    public static int IntegerLerp(int i, int min1, int max1, int min2, int max2)
    {
      int offset = min2 < 0 ? Math.Abs(min2) : 0;
      min2 += offset;
      max2 += offset;

      double x = (double)i;
      double x0 = (double)min1;
      double x1 = (double)max1;
      double y0 = (double)min2;
      double y1 = (double)max2;

      double lerp = y0 + (x - x0) * (y1 - y0) / (x1 - x0);
      int result = (int)Math.Round(lerp);
      result -= offset;
      return result;
    }
  }
}
