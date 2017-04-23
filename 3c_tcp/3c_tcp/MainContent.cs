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
    public partial class MainContent : Form
    {
        EnvironmentTracking environment_track = new EnvironmentTracking();
        Data_exhibition data_exhibition = new Data_exhibition();
        public MainContent()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        String remove_index = " ";
        private void changeControls(String add_index)
        {
            switch (remove_index)
            {
                case "T":
                    this.Controls.Remove(environment_track);
                    break;
                case "H":
                    this.Controls.Remove(data_exhibition);
                    break;
            }
            switch (add_index)
            {
                case "T":
                    this.Controls.Add(environment_track);
                    break;
                case "H":
                    this.Controls.Add(data_exhibition);
                    break;    
            }
            remove_index = add_index;
             
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            changeControls("T");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            changeControls("H");
        }
    }
}
