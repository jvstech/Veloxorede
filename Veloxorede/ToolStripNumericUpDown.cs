using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Veloxorede
{
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
  public class ToolStripNumericUpDown : ToolStripControlHost
  {
    public ToolStripNumericUpDown()
      : base(new NumericUpDown())
    {
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((NumericUpDown)control).ValueChanged += new EventHandler(OnValueChanged);
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((NumericUpDown)control).ValueChanged -= new EventHandler(OnValueChanged);
    }

    public event EventHandler ValueChanged;

    public Control NumericUpDownControl
    {
      get { return Control as NumericUpDown; }
    }

    public decimal Value
    {
      get => (NumericUpDownControl as NumericUpDown).Value;
      set => (NumericUpDownControl as NumericUpDown).Value = value;
    }

    public decimal Minimum
    {
      get => (NumericUpDownControl as NumericUpDown).Minimum;
      set => (NumericUpDownControl as NumericUpDown).Minimum = value;
    }

    public decimal Maximum
    {
      get => (NumericUpDownControl as NumericUpDown).Maximum;
      set => (NumericUpDownControl as NumericUpDown).Maximum = value;
    }

    public decimal Increment
    {
      get => (NumericUpDownControl as NumericUpDown).Increment;
      set => (NumericUpDownControl as NumericUpDown).Increment = value;
    }

    protected void OnValueChanged(object sender, EventArgs e)
    {
      ValueChanged?.Invoke(this, e);
    }
  }
}
