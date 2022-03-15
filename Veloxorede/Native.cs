using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Veloxorede
{
  public class Native
  {
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
      StringBuilder lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, 
      [MarshalAs(UnmanagedType.LPWStr)] string lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, 
      [MarshalAs(UnmanagedType.LPWStr)] string lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, 
      ref IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, 
      IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, 
      int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, 
      ref PARAFORMAT paraFmt);

    public const int PFM_SPACEBEFORE = 0x00000040;
    public const int PFM_SPACEAFTER = 0x00000080;
    public const int PFM_LINESPACING = 0x00000100;
    public const int SCF_SELECTION = 1;
    public const int EM_GETPARAFORMAT = 1085;
    public const int EM_SETPARAFORMAT = 1095;

    [StructLayout(LayoutKind.Sequential)]
    public struct PARAFORMAT
    {
      public int cbSize;
      public uint dwMask;
      public short wNumbering;
      public short wReserved;
      public int dxStartIndent;
      public int dxRightIndent;
      public int dxOffset;
      public short wAlignment;
      public short cTabCount;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
      public int[] rgxTabs;
      // PARAFORMAT2 from here onwards
      public int dySpaceBefore;
      public int dySpaceAfter;
      public int dyLineSpacing;
      public short sStyle;
      public byte bLineSpacingRule;
      public byte bOutlineLevel;
      public short wShadingWeight;
      public short wShadingStyle;
      public short wNumberingStart;
      public short wNumberingStyle;
      public short wNumberingTab;
      public short wBorderSpace;
      public short wBorderWidth;
      public short wBorders;
    }
  }
}
