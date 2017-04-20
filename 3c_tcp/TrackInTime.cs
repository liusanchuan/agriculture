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
    public partial class TrackInTime : UserControl
    {
        Environment_DataDataContext en_d = new Environment_DataDataContext();
        public TrackInTime()
        {
            InitializeComponent();
            
        }

        private void TrackInTime_Load(object sender, EventArgs e)
        {
            var Temp = from temp in en_d.environemt_data
                       select temp;
            List<double> Temp_=new List<double>();
            List<double> Humi_ = new List<double>();
            foreach(var i in Temp){
                Temp_.Add(Convert.ToDouble(i.temp ));
                Humi_.Add(Convert.ToDouble(i.humi));
            }
            chart_tempreture.Series[0].Points.DataBindY(Temp_);
            Chart_Humi_value.Series[0].Points.DataBindY(Humi_);
        }

    }
}
