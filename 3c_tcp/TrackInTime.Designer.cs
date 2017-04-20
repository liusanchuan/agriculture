namespace _3c_tcp
{
    partial class TrackInTime
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_tempreture = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart_Humi_value = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_tempreture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Humi_value)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_tempreture
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_tempreture.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_tempreture.Legends.Add(legend1);
            this.chart_tempreture.Location = new System.Drawing.Point(3, 12);
            this.chart_tempreture.Name = "chart_tempreture";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "温度";
            this.chart_tempreture.Series.Add(series1);
            this.chart_tempreture.Size = new System.Drawing.Size(405, 186);
            this.chart_tempreture.TabIndex = 0;
            this.chart_tempreture.Text = "chart1";
            // 
            // Chart_Humi_value
            // 
            chartArea2.Name = "ChartArea1";
            this.Chart_Humi_value.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Chart_Humi_value.Legends.Add(legend2);
            this.Chart_Humi_value.Location = new System.Drawing.Point(3, 185);
            this.Chart_Humi_value.Name = "Chart_Humi_value";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "湿度";
            this.Chart_Humi_value.Series.Add(series2);
            this.Chart_Humi_value.Size = new System.Drawing.Size(405, 164);
            this.Chart_Humi_value.TabIndex = 1;
            this.Chart_Humi_value.Text = "chart1";
            // 
            // TrackInTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Chart_Humi_value);
            this.Controls.Add(this.chart_tempreture);
            this.Name = "TrackInTime";
            this.Size = new System.Drawing.Size(530, 400);
            this.Load += new System.EventHandler(this.TrackInTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_tempreture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Humi_value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_tempreture;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Humi_value;

    }
}
