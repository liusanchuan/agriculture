namespace _3c_tcp
{
    partial class EnvironmentTracking
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar_L = new System.Windows.Forms.ProgressBar();
            this.progressBar_H = new System.Windows.Forms.ProgressBar();
            this.progressBar_T = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_TrackTime = new System.Windows.Forms.TextBox();
            this.timer_TrackData = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_TrackTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.progressBar_L);
            this.groupBox1.Controls.Add(this.progressBar_H);
            this.groupBox1.Controls.Add(this.progressBar_T);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(395, 253);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "环境数据";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "光照强度（Lux）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前湿度（g/m³）：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前温度（℃）：";
            // 
            // progressBar_L
            // 
            this.progressBar_L.ForeColor = System.Drawing.Color.Red;
            this.progressBar_L.Location = new System.Drawing.Point(185, 180);
            this.progressBar_L.Name = "progressBar_L";
            this.progressBar_L.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar_L.Size = new System.Drawing.Size(200, 10);
            this.progressBar_L.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_L.TabIndex = 0;
            this.progressBar_L.Value = 60;
            // 
            // progressBar_H
            // 
            this.progressBar_H.ForeColor = System.Drawing.Color.Red;
            this.progressBar_H.Location = new System.Drawing.Point(185, 124);
            this.progressBar_H.Name = "progressBar_H";
            this.progressBar_H.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar_H.Size = new System.Drawing.Size(200, 10);
            this.progressBar_H.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_H.TabIndex = 0;
            this.progressBar_H.Value = 60;
            // 
            // progressBar_T
            // 
            this.progressBar_T.ForeColor = System.Drawing.Color.Red;
            this.progressBar_T.Location = new System.Drawing.Point(185, 63);
            this.progressBar_T.Name = "progressBar_T";
            this.progressBar_T.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar_T.Size = new System.Drawing.Size(200, 10);
            this.progressBar_T.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_T.TabIndex = 0;
            this.progressBar_T.Value = 60;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(410, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(235, 380);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能组件";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(5, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 119);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "警报信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "记录时间:";
            // 
            // tb_TrackTime
            // 
            this.tb_TrackTime.Enabled = false;
            this.tb_TrackTime.Location = new System.Drawing.Point(185, 216);
            this.tb_TrackTime.Name = "tb_TrackTime";
            this.tb_TrackTime.Size = new System.Drawing.Size(160, 29);
            this.tb_TrackTime.TabIndex = 6;
            // 
            // timer_TrackData
            // 
            this.timer_TrackData.Enabled = true;
            this.timer_TrackData.Interval = 500;
            this.timer_TrackData.Tick += new System.EventHandler(this.timer_TrackData_Tick);
            // 
            // EnvironmentTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EnvironmentTracking";
            this.Size = new System.Drawing.Size(650, 400);
            this.Load += new System.EventHandler(this.EnvironmentTracking_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar_L;
        private System.Windows.Forms.ProgressBar progressBar_H;
        public System.Windows.Forms.ProgressBar progressBar_T;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_TrackTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_TrackData;
    }
}
