namespace Veloxorede
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.contentContainer = new System.Windows.Forms.ToolStripContainer();
      this.tabs = new System.Windows.Forms.TabControl();
      this.inputTab = new System.Windows.Forms.TabPage();
      this.inputText = new System.Windows.Forms.RichTextBox();
      this.groupingTab = new System.Windows.Forms.TabPage();
      this.scrollingTab = new System.Windows.Forms.TabPage();
      this.scrollingText = new System.Windows.Forms.RichTextBox();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.fileMenu = new System.Windows.Forms.ToolStripDropDownButton();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.speedMenu = new System.Windows.Forms.ToolStripDropDownButton();
      this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.increaseGroupSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.decreaseGroupSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip2 = new System.Windows.Forms.ToolStrip();
      this.intervalLabel = new System.Windows.Forms.ToolStripLabel();
      this.intervalValue = new Veloxorede.ToolStripNumericUpDown();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.groupSizeLabel = new System.Windows.Forms.ToolStripLabel();
      this.groupSizeValue = new Veloxorede.ToolStripNumericUpDown();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.startStopButton = new System.Windows.Forms.ToolStripButton();
      this.pauseButton = new System.Windows.Forms.ToolStripButton();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.contentContainer.ContentPanel.SuspendLayout();
      this.contentContainer.TopToolStripPanel.SuspendLayout();
      this.contentContainer.SuspendLayout();
      this.tabs.SuspendLayout();
      this.inputTab.SuspendLayout();
      this.scrollingTab.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contentContainer
      // 
      // 
      // contentContainer.ContentPanel
      // 
      this.contentContainer.ContentPanel.Controls.Add(this.tabs);
      this.contentContainer.ContentPanel.Size = new System.Drawing.Size(800, 402);
      this.contentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.contentContainer.Location = new System.Drawing.Point(0, 0);
      this.contentContainer.Name = "contentContainer";
      this.contentContainer.Size = new System.Drawing.Size(800, 428);
      this.contentContainer.TabIndex = 1;
      this.contentContainer.Text = "toolStripContainer1";
      // 
      // contentContainer.TopToolStripPanel
      // 
      this.contentContainer.TopToolStripPanel.Controls.Add(this.toolStrip1);
      this.contentContainer.TopToolStripPanel.Controls.Add(this.toolStrip2);
      // 
      // tabs
      // 
      this.tabs.Controls.Add(this.inputTab);
      this.tabs.Controls.Add(this.groupingTab);
      this.tabs.Controls.Add(this.scrollingTab);
      this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabs.Location = new System.Drawing.Point(0, 0);
      this.tabs.Name = "tabs";
      this.tabs.SelectedIndex = 0;
      this.tabs.Size = new System.Drawing.Size(800, 402);
      this.tabs.TabIndex = 1;
      // 
      // inputTab
      // 
      this.inputTab.Controls.Add(this.inputText);
      this.inputTab.Location = new System.Drawing.Point(4, 22);
      this.inputTab.Name = "inputTab";
      this.inputTab.Padding = new System.Windows.Forms.Padding(3);
      this.inputTab.Size = new System.Drawing.Size(792, 376);
      this.inputTab.TabIndex = 0;
      this.inputTab.Text = "Input";
      this.inputTab.UseVisualStyleBackColor = true;
      // 
      // inputText
      // 
      this.inputText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.inputText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.inputText.Location = new System.Drawing.Point(3, 3);
      this.inputText.Name = "inputText";
      this.inputText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      this.inputText.Size = new System.Drawing.Size(786, 370);
      this.inputText.TabIndex = 0;
      this.inputText.Text = "";
      this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
      // 
      // groupingTab
      // 
      this.groupingTab.Location = new System.Drawing.Point(4, 22);
      this.groupingTab.Name = "groupingTab";
      this.groupingTab.Padding = new System.Windows.Forms.Padding(3);
      this.groupingTab.Size = new System.Drawing.Size(792, 376);
      this.groupingTab.TabIndex = 1;
      this.groupingTab.Text = "Grouping";
      this.groupingTab.UseVisualStyleBackColor = true;
      // 
      // scrollingTab
      // 
      this.scrollingTab.Controls.Add(this.scrollingText);
      this.scrollingTab.Location = new System.Drawing.Point(4, 22);
      this.scrollingTab.Name = "scrollingTab";
      this.scrollingTab.Padding = new System.Windows.Forms.Padding(3);
      this.scrollingTab.Size = new System.Drawing.Size(792, 376);
      this.scrollingTab.TabIndex = 2;
      this.scrollingTab.Text = "Scrolling";
      this.scrollingTab.UseVisualStyleBackColor = true;
      // 
      // scrollingText
      // 
      this.scrollingText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scrollingText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.scrollingText.Location = new System.Drawing.Point(3, 3);
      this.scrollingText.Name = "scrollingText";
      this.scrollingText.ReadOnly = true;
      this.scrollingText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      this.scrollingText.Size = new System.Drawing.Size(786, 370);
      this.scrollingText.TabIndex = 1;
      this.scrollingText.Text = "";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.speedMenu});
      this.toolStrip1.Location = new System.Drawing.Point(3, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(84, 25);
      this.toolStrip1.TabIndex = 0;
      // 
      // fileMenu
      // 
      this.fileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
      this.fileMenu.Image = ((System.Drawing.Image)(resources.GetObject("fileMenu.Image")));
      this.fileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.fileMenu.Name = "fileMenu";
      this.fileMenu.ShowDropDownArrow = false;
      this.fileMenu.Size = new System.Drawing.Size(29, 22);
      this.fileMenu.Text = "&File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.openToolStripMenuItem.Text = "&Open...";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      // 
      // speedMenu
      // 
      this.speedMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.speedMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem,
            this.toolStripSeparator4,
            this.increaseGroupSizeToolStripMenuItem,
            this.decreaseGroupSizeToolStripMenuItem});
      this.speedMenu.Image = ((System.Drawing.Image)(resources.GetObject("speedMenu.Image")));
      this.speedMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.speedMenu.Name = "speedMenu";
      this.speedMenu.ShowDropDownArrow = false;
      this.speedMenu.Size = new System.Drawing.Size(43, 22);
      this.speedMenu.Text = "&Speed";
      // 
      // increaseToolStripMenuItem
      // 
      this.increaseToolStripMenuItem.Image = global::Veloxorede.Properties.Resources.up_circular_16;
      this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
      this.increaseToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+=";
      this.increaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
      this.increaseToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
      this.increaseToolStripMenuItem.Text = "&Increase";
      this.increaseToolStripMenuItem.Click += new System.EventHandler(this.increaseToolStripMenuItem_Click);
      // 
      // decreaseToolStripMenuItem
      // 
      this.decreaseToolStripMenuItem.Image = global::Veloxorede.Properties.Resources.down_circular_16;
      this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
      this.decreaseToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+-";
      this.decreaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
      this.decreaseToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
      this.decreaseToolStripMenuItem.Text = "&Decrease";
      this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.decreaseToolStripMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
      // 
      // increaseGroupSizeToolStripMenuItem
      // 
      this.increaseGroupSizeToolStripMenuItem.Name = "increaseGroupSizeToolStripMenuItem";
      this.increaseGroupSizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
      this.increaseGroupSizeToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
      this.increaseGroupSizeToolStripMenuItem.Text = "I&ncrease Group Size";
      // 
      // decreaseGroupSizeToolStripMenuItem
      // 
      this.decreaseGroupSizeToolStripMenuItem.Name = "decreaseGroupSizeToolStripMenuItem";
      this.decreaseGroupSizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
      this.decreaseGroupSizeToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
      this.decreaseGroupSizeToolStripMenuItem.Text = "D&ecrease Group Size";
      // 
      // toolStrip2
      // 
      this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intervalLabel,
            this.intervalValue,
            this.toolStripSeparator2,
            this.groupSizeLabel,
            this.groupSizeValue,
            this.toolStripSeparator3,
            this.startStopButton,
            this.pauseButton});
      this.toolStrip2.Location = new System.Drawing.Point(87, 0);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new System.Drawing.Size(334, 26);
      this.toolStrip2.TabIndex = 1;
      // 
      // intervalLabel
      // 
      this.intervalLabel.Name = "intervalLabel";
      this.intervalLabel.Size = new System.Drawing.Size(49, 23);
      this.intervalLabel.Text = "Interval:";
      // 
      // intervalValue
      // 
      this.intervalValue.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.intervalValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.intervalValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.intervalValue.Name = "intervalValue";
      this.intervalValue.Size = new System.Drawing.Size(41, 23);
      this.intervalValue.Text = "500";
      this.intervalValue.Value = global::Veloxorede.Properties.Settings.Default.Interval;
      this.intervalValue.ValueChanged += new System.EventHandler(this.intervalValue_ValueChanged);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
      // 
      // groupSizeLabel
      // 
      this.groupSizeLabel.Name = "groupSizeLabel";
      this.groupSizeLabel.Size = new System.Drawing.Size(108, 23);
      this.groupSizeLabel.Text = "Group size (words):";
      // 
      // groupSizeValue
      // 
      this.groupSizeValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.groupSizeValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.groupSizeValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.groupSizeValue.Name = "groupSizeValue";
      this.groupSizeValue.Size = new System.Drawing.Size(35, 23);
      this.groupSizeValue.Text = "1";
      this.groupSizeValue.Value = global::Veloxorede.Properties.Settings.Default.GroupSize;
      this.groupSizeValue.ValueChanged += new System.EventHandler(this.groupSizeValue_ValueChanged);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
      // 
      // startStopButton
      // 
      this.startStopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.startStopButton.Image = global::Veloxorede.Properties.Resources.play_6_16;
      this.startStopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.startStopButton.Name = "startStopButton";
      this.startStopButton.Size = new System.Drawing.Size(23, 23);
      this.startStopButton.Text = "Start";
      this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
      // 
      // pauseButton
      // 
      this.pauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.pauseButton.Enabled = false;
      this.pauseButton.Image = global::Veloxorede.Properties.Resources.pause_16;
      this.pauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pauseButton.Name = "pauseButton";
      this.pauseButton.Size = new System.Drawing.Size(23, 23);
      this.pauseButton.Text = "Pause";
      this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 428);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(800, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // progressBar
      // 
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(100, 16);
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.contentContainer);
      this.Controls.Add(this.statusStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Veloxorede";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.contentContainer.ContentPanel.ResumeLayout(false);
      this.contentContainer.TopToolStripPanel.ResumeLayout(false);
      this.contentContainer.TopToolStripPanel.PerformLayout();
      this.contentContainer.ResumeLayout(false);
      this.contentContainer.PerformLayout();
      this.tabs.ResumeLayout(false);
      this.inputTab.ResumeLayout(false);
      this.scrollingTab.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripContainer contentContainer;
    private System.Windows.Forms.TabControl tabs;
    private System.Windows.Forms.TabPage inputTab;
    private System.Windows.Forms.RichTextBox inputText;
    private System.Windows.Forms.TabPage groupingTab;
    private System.Windows.Forms.TabPage scrollingTab;
    private System.Windows.Forms.RichTextBox scrollingText;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripDropDownButton fileMenu;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip2;
    private System.Windows.Forms.ToolStripLabel intervalLabel;
    private System.Windows.Forms.ToolStripDropDownButton speedMenu;
    private ToolStripNumericUpDown intervalValue;
    private System.Windows.Forms.ToolStripMenuItem increaseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem decreaseToolStripMenuItem;
    private System.Windows.Forms.ToolStripLabel groupSizeLabel;
    private ToolStripNumericUpDown groupSizeValue;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton startStopButton;
    private System.Windows.Forms.ToolStripButton pauseButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem increaseGroupSizeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem decreaseGroupSizeToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripProgressBar progressBar;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
  }
}

