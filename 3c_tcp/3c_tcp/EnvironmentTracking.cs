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
    public partial class EnvironmentTracking : UserControl
    {
        public EnvironmentTracking()
        {
            InitializeComponent();
        }

        private void EnvironmentTracking_Load(object sender, EventArgs e)
        {
            AppendData();
        }

        void AppendData()
        {
            Latast_data la_d = Latast_data.getSingleon();
            progressBar_T.Value = (int)la_d.Temperature;
            progressBar_H.Value = (int)la_d.Humi;
            progressBar_L.Value = (int)la_d.Light;
            tb_TrackTime.Text = la_d.datatime.ToString();
        }

        private void timer_TrackData_Tick(object sender, EventArgs e)
        {
            AppendData();
            this.Refresh();
        }
    }
}
