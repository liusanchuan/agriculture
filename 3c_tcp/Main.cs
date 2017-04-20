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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            TrackInTime tIT=new TrackInTime();
            this.Controls.Add(tIT);
            this.Refresh();
        }
    }
}
