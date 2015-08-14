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
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
      this.SuspendLayout();
      // 
      // logTextBox
      // 
      this.logTextBox.Dock = System.Windows.Forms.DockStyle.Top;
      this.logTextBox.Location = new System.Drawing.Point(0, 0);
      this.logTextBox.Multiline = true;
      this.logTextBox.Name = "logTextBox";
      this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.logTextBox.Size = new System.Drawing.Size(833, 163);
      this.logTextBox.TabIndex = 0;
      // 
      // chart1
      // 
      chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
      chartArea1.Name = "ChartArea1";
      this.chart1.ChartAreas.Add(chartArea1);
      this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chart1.Location = new System.Drawing.Point(0, 163);
      this.chart1.Name = "chart1";
      series1.BorderWidth = 2;
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series1.Name = "Temperature";
      series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      this.chart1.Series.Add(series1);
      this.chart1.Size = new System.Drawing.Size(833, 507);
      this.chart1.TabIndex = 1;
      this.chart1.Text = "chart1";
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.BackColor = System.Drawing.SystemColors.Window;
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox1.Location = new System.Drawing.Point(3, 650);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(136, 17);
      this.checkBox1.TabIndex = 2;
      this.checkBox1.Text = "Lock y-minimum to zero";
      this.checkBox1.UseVisualStyleBackColor = false;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // TemperatureForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(833, 670);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.chart1);
      this.Controls.Add(this.logTextBox);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "TemperatureForm";
      this.Text = "Current Temperature";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisposeReader);
      this.Load += new System.EventHandler(this.FormLoaded);
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox logTextBox;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.CheckBox checkBox1;
  }
}

