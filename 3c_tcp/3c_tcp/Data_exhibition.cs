using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3c_tcp
{
    public partial class Data_exhibition : UserControl
    {
        public Data_exhibition()
        {
            InitializeComponent();
        }
        Environment_dataDataContext S_env = Sql_Environment.Create_Environment_SqlData();

        private void Data_exhibition_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = S_env.Env_Data;

        }
        void ChangeChartContext(int index)
        {
            String[] SeriesLabel =
            {
                "温度",
                "湿度",
                "光照强度",
                "烟雾浓度"
            };
            chart1.Series[0].Name = SeriesLabel[index];
            chart1.Series[0].Points.Clear();
            foreach(var i in S_env.Env_Data)
            {
                double? value = 0;
                switch (index) {
                    case 0:value = i.Temperature_;
                        break;
                    case 1:
                        value = i.Humi_;
                        break;
                    case 2:
                        value = i.light;
                        break;
                    case 3:
                        value = i.smokescope_;
                        break;
                }

                chart1.Series[0].Points.AddXY(i.DataTime_, value);
            }
        }
        private void toolStripButton_Tempreture_Click(object sender, EventArgs e)
        {
            ChangeChartContext(0);
        }

        private void toolStripButton_humi_Click(object sender, EventArgs e)
        {
            ChangeChartContext(1);
        }

        private void toolStripButton_light_Click(object sender, EventArgs e)
        {
            ChangeChartContext(2);
        }

        private void toolStripButton_smoke_Click(object sender, EventArgs e)
        {
            ChangeChartContext(3);
        }
    }
}
