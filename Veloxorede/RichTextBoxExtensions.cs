using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veloxorede
{
  public static class RichTextBoxExtensions
  {
    public static int GetVisibleTopLine(this RichTextBox @this)
    {
      return @this.GetLineFromCharIndex(@this.GetCharIndexFromPosition(
        new Point(1, 1)));
    }

    public static int GetVisibleBottomLine(this RichTextBox @this)
    {
      return @this.GetLineFromCharIndex(@this.GetCharIndexFromPosition(
        new Point(1, @this.Height - 1)));
    }

    public static int GetVisibleLineCount(this RichTextBox @this)
    {
      return @this.GetVisibleBottomLine() - @this.GetVisibleTopLine() + 1;
    }

    public static int[] GetVisibleLineStartIndicies(this RichTextBox @this)
    {
      var topLine = @this.GetVisibleTopLine();
      var bottomLine = @this.GetVisibleBottomLine();
      return Enumerable.Range(topLine, (bottomLine - topLine + 1))
        .Select(i => @this.GetFirstCharIndexFromLine(i))
        .ToArray();
    }

    public static RichTextBox Scroll(this RichTextBox @this, int lines = 1)
    {
      const int EM_LINESCROLL = 0xB6;
      Native.SendMessage(@this.Handle, EM_LINESCROLL, 0, lines);
      return @this;
    }

    public static RichTextBox ScrollDown(this RichTextBox @this, int lines = 1)
    {
      return @this.Scroll(lines);
    }

    public static RichTextBox ScrollUp(this RichTextBox @this, int lines = 1)
    {
      return @this.ScrollDown(-(lines));
    }

    public static RichTextBox ScrollToBottom(this RichTextBox @this)
    {
      const int WM_VSCROLL = 0x115;
      const int SB_BOTTOM = 7;
      Native.SendMessage(@this.Handle, WM_VSCROLL, SB_BOTTOM, 0);
      return @this;
    }

    public static RichTextBox ScrollToSelectionStart(this RichTextBox @this)
    {
      // Determine if the selection position is above or below the visible
      // lines
      var currentLine = @this.GetLineFromCharIndex(@this.SelectionStart);
      var topLine = @this.GetVisibleTopLine();
      var bottomLine = @this.GetVisibleBottomLine();
      int lineScrollCount = 0;
      if (currentLine < topLine)
      {
        // scroll up
        lineScrollCount = currentLine - topLine;
      }
      else if (currentLine > bottomLine)
      {
        // scroll down
        lineScrollCount = currentLine - bottomLine;
      }

      if (lineScrollCount != 0)
      {
        @this.Scroll(lineScrollCount);
      }

      return @this;
    }
  }
}
