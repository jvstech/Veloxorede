using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veloxorede
{
  public struct TextLocation
  {
    public TextLocation(int start, int length, TextType textType)
    {
      this.Start = start;
      this.Length = length;
      this.Type = textType;
    }

    public int Start { get; }
    public int Length { get; }
    public int End => Start + Length;
    public TextType Type { get; }

    public string GetText(string sourceString)
    {
      return sourceString.Substring(Start, Length);
    }
  }
}
