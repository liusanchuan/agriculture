namespace _3c_tcp
{
    partial class Data_exhibition
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Data_exhibition));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Tempreture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_humi = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_smoke = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_light = new System.Windows.Forms.ToolStripButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(13, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(626, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(606, 328);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(614, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据曲线";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Tempreture,
            this.toolStripButton_humi,
            this.toolStripButton_light,
            this.toolStripButton_smoke});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(608, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Tempreture
            // 
            this.toolStripButton_Tempreture.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Tempreture.Image")));
            this.toolStripButton_Tempreture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Tempreture.Name = "toolStripButton_Tempreture";
            this.toolStripButton_Tempreture.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_Tempreture.Text = "温度曲线";
            this.toolStripButton_Tempreture.Click += new System.EventHandler(this.toolStripButton_Tempreture_Click);
            // 
            // toolStripButton_humi
            // 
            this.toolStripButton_humi.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_humi.Image")));
            this.toolStripButton_humi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_humi.Name = "toolStripButton_humi";
            this.toolStripButton_humi.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_humi.Text = "湿度曲线";
            this.toolStripButton_humi.Click += new System.EventHandler(this.toolStripButton_humi_Click);
            // 
            // toolStripButton_smoke
            // 
            this.toolStripButton_smoke.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_smoke.Image")));
            this.toolStripButton_smoke.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_smoke.Name = "toolStripButton_smoke";
            this.toolStripButton_smoke.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton_smoke.Text = "烟雾浓度曲线";
            this.toolStripButton_smoke.Click += new System.EventHandler(this.toolStripButton_smoke_Click);
            // 
            // toolStripButton_light
            // 
            this.toolStripButton_light.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_light.Image")));
            this.toolStripButton_light.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_light.Name = "toolStripButton_light";
            this.toolStripButton_light.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton_light.Text = "光照强度曲线";
            this.toolStripButton_light.Click += new System.EventHandler(this.toolStripButton_light_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 31);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "12";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(614, 280);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // Data_exhibition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Data_exhibition";
            this.Size = new System.Drawing.Size(650, 383);
            this.Load += new System.EventHandler(this.Data_exhibition_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Tempreture;
        private System.Windows.Forms.ToolStripButton toolStripButton_humi;
        private System.Windows.Forms.ToolStripButton toolStripButton_light;
        private System.Windows.Forms.ToolStripButton toolStripButton_smoke;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
