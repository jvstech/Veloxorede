using System;
using System.Collections.Generic;
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

    public static List<TextLocation> Parse(string text, 
      Action<string> onWordParsed = null,
      Action<string> onSpaceParsed = null)
    {
      List<TextLocation> locations = new List<TextLocation>();
      if (string.IsNullOrEmpty(text))
      {
        return locations;
      }

      int nextSpaceIdx = 0;

      var m = Regex.Match(text, @"[^\s\r\n]+");
      while (m.Success)
      {
        if (m.Index > nextSpaceIdx)
        {
          onSpaceParsed?.Invoke(text.Substring(nextSpaceIdx, 
            (m.Index - nextSpaceIdx)));
          locations.Add(new TextLocation(nextSpaceIdx, (m.Index - nextSpaceIdx), 
            TextType.Space));
        }

        onWordParsed?.Invoke(m.Value);
        locations.Add(new TextLocation(m.Index, m.Length, TextType.Word));
        nextSpaceIdx = m.Index + m.Length;
        m = m.NextMatch();
      }

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
  }
}
