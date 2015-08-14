namespace Serial_Temperature
{
  partial class TemperatureForm
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureForm));
      this.logTextBox = new System.Windows.Forms.TextBox();
      this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.zeroCheckBox = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.optionsPanel = new System.Windows.Forms.Panel();
      this.splineCheckBox = new System.Windows.Forms.CheckBox();
      this.button1 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
      this.panel1.SuspendLayout();
      this.optionsPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // logTextBox
      // 
      this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.logTextBox.Location = new System.Drawing.Point(0, 0);
      this.logTextBox.Multiline = true;
      this.logTextBox.Name = "logTextBox";
      this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.logTextBox.Size = new System.Drawing.Size(633, 140);
      this.logTextBox.TabIndex = 0;
      // 
      // chart1
      // 
      chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
      chartArea1.Name = "ChartArea1";
      this.chart1.ChartAreas.Add(chartArea1);
      this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chart1.Location = new System.Drawing.Point(0, 140);
      this.chart1.Name = "chart1";
      series1.BorderWidth = 2;
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series1.Name = "Temperature";
      series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      this.chart1.Series.Add(series1);
      this.chart1.Size = new System.Drawing.Size(833, 530);
      this.chart1.TabIndex = 1;
      this.chart1.Text = "chart1";
      // 
      // zeroCheckBox
      // 
      this.zeroCheckBox.AutoSize = true;
      this.zeroCheckBox.BackColor = System.Drawing.SystemColors.Window;
      this.zeroCheckBox.Checked = true;
      this.zeroCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.zeroCheckBox.Location = new System.Drawing.Point(6, 3);
      this.zeroCheckBox.Name = "zeroCheckBox";
      this.zeroCheckBox.Size = new System.Drawing.Size(136, 17);
      this.zeroCheckBox.TabIndex = 2;
      this.zeroCheckBox.Text = "Lock y-minimum to zero";
      this.zeroCheckBox.UseVisualStyleBackColor = false;
      this.zeroCheckBox.CheckedChanged += new System.EventHandler(this.ZeroCheckBoxChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.logTextBox);
      this.panel1.Controls.Add(this.optionsPanel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(833, 140);
      this.panel1.TabIndex = 3;
      // 
      // optionsPanel
      // 
      this.optionsPanel.BackColor = System.Drawing.SystemColors.Window;
      this.optionsPanel.Controls.Add(this.button1);
      this.optionsPanel.Controls.Add(this.splineCheckBox);
      this.optionsPanel.Controls.Add(this.zeroCheckBox);
      this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
      this.optionsPanel.Location = new System.Drawing.Point(633, 0);
      this.optionsPanel.Name = "optionsPanel";
      this.optionsPanel.Size = new System.Drawing.Size(200, 140);
      this.optionsPanel.TabIndex = 1;
      // 
      // splineCheckBox
      // 
      this.splineCheckBox.AutoSize = true;
      this.splineCheckBox.BackColor = System.Drawing.SystemColors.Window;
      this.splineCheckBox.Location = new System.Drawing.Point(6, 26);
      this.splineCheckBox.Name = "splineCheckBox";
      this.splineCheckBox.Size = new System.Drawing.Size(103, 17);
      this.splineCheckBox.TabIndex = 3;
      this.splineCheckBox.Text = "Spline the graph";
      this.splineCheckBox.UseVisualStyleBackColor = false;
      this.splineCheckBox.CheckedChanged += new System.EventHandler(this.splineCheckBox_CheckedChanged);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(6, 111);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 4;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // TemperatureForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(833, 670);
      this.Controls.Add(this.chart1);
      this.Controls.Add(this.panel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "TemperatureForm";
      this.Text = "Current Temperature";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisposeReader);
      this.Load += new System.EventHandler(this.FormLoaded);
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.optionsPanel.ResumeLayout(false);
      this.optionsPanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox logTextBox;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.CheckBox zeroCheckBox;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel optionsPanel;
    private System.Windows.Forms.CheckBox splineCheckBox;
    private System.Windows.Forms.Button button1;
  }
}

