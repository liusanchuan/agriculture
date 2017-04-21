using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3c_tcp
{
    public partial class ShowLader : Form
    {

        public double[] Point_list=new double[360];
        System.Timers.Timer timer13= new System.Timers.Timer();
        public ShowLader()
        {
            InitializeComponent();

        }
 
        private void ShowLader_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Point_list.Count(); i++)
            {
                Point_list[i] = 0;
            }
                SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            chart1_frash();
        }
        private void chart1_frash()
        {
        //{
        //    chart1.Series[0].Points.Clear();
        //    chart1.Series[0].Points.AddXY(0,0);
        //    chart1.Series[0].Points.AddXY(360,0);

                chart1.Series[0].Points.DataBindY(Point_list);
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1_frash();
            
        }
    }
}
