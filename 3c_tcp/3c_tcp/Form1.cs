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
    public partial class Form1 : Form
    {
        private float scaleSize = 1.0f;
        private float translateX = 0, translateY = 0,basicPosX=200,basicPosY=200;

        public double[]position = new double[8];
        public int[] LandR = new int[2]{5,5};   //左右两轮的行进距离
        private List<double[]> path_list=new List<double[]>();
        private int cursor_x=0,cursor_y=0;
        private bool isMouseDown=false;
        public String Dir = "$0";//地图中显示方向
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲 
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            path_list.Add(new double[4] { -10, 0, 10, 0 });

        }
        private void DrawPath()
        {
            //if (LandR[0] != LandR[1])
            //{
            //    return;
            //}
            //局部坐标系中的坐标
            //int[][] pos = new int[path_list.Count][];
            double[] StartPos = new double[4] { -10, 0, 10, 0 };
            
            int[] EndPos = new int[4] ;
            if (LandR[0] == LandR[1])
            {
                EndPos[0]=-10;
                EndPos[2]=10;
                EndPos[1]=EndPos[3]=LandR[0];
            }
            else
            {
                double Rotate_cet = LandR[0] / (2 * Math.PI * 10.0)*360;
                //按照做圆弧处理
                EndPos[0] = (int)(LandR[0] * Math.Cos(Rotate_cet));
                EndPos[1] = (int)(LandR[0] * Math.Sin(Rotate_cet));
                EndPos[2] = -EndPos[0];
                EndPos[3] = -EndPos[1];
                
                //pos[i + 1] = new int[2] { pos[i][0] + LandR[0], pos[i][1] + LandR[1] };
                //if (LandR[0] > 0)//left wheel go head;
                //{
                //    for (int i = 0; i < EndPos.Length; i++)
                //    {
                //        EndPos[i] = -EndPos[i];
                //    }
                //}
            }

            //坐标变化系数
            double X = 0, Y = 0, C = 0;
                if (LandR[0] == LandR[1])
                {
                    //按平行线处理
                    //从局部坐标（x`，y`）变化到全局坐标，变化系数（X，Y，C）
                    if (LandR[0] > 0)
                    {
                        Y += LandR[0];
                    }
                    else
                    {
                        Y -= LandR[0];
                    }

                }
                else
                {
                    //按照做圆弧处理
                    //pos[i + 1] = new int[2] { pos[i][0] + LandR[0], pos[i][1] + LandR[1] };
                    if(LandR[0]>0)//left wheel go head;
                    {
                        C +=360*  LandR[0] /(2*Math.PI*10);
                    }
                    else
                    {
                        C -= 360*  LandR[0] /(2*Math.PI*10);
                    }
                }
                for (int i = 0; i < path_list.Count; i++)
                {
                    double cet = -C;
                    path_list[i][0] = path_list[i][1] * Math.Sin(cet) + path_list[i][0] * Math.Cos(cet) + X;
                    path_list[i][1] = path_list[i][0] * Math.Cos(cet) - path_list[i][1] * Math.Sin(cet) + Y;

                    path_list[i][2] = path_list[i][2] * Math.Cos(cet) + path_list[i][3] * Math.Sin(cet) + X;
                    path_list[i][3] = path_list[i][3] * Math.Cos(cet) - path_list[i][2] * Math.Sin(cet) + Y;
                }
                path_list.Add(StartPos);
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            DateTime datetime = DateTime.Now;
            label1.Text = datetime.ToString();
            Graphics g = e.Graphics;
            g.ScaleTransform(scaleSize, scaleSize);

            g.TranslateTransform(basicPosX+translateX, basicPosY+translateY);
            g.RotateTransform(90);

            Point []P_set=new Point[8]{
                new Point((int)position[0], 0),
                new Point((int)(0.707*position[1]), (int)(0.707*position[1])),
                new Point(0, (int)position[2]),
                new Point((int)(-0.707*position[3]), (int)(0.707*position[3])),
                new Point(-(int)position[4],0),
                new Point(-(int)(0.707 * position[5]), -(int)(0.707 * position[5])),
                new Point(0,-(int)position[6]),
                new Point((int)(0.707 * position[7]), -(int)(0.707 * position[7]))
            };
            
            g.DrawLine(Pens.Red, new Point(0, 0), new Point((int)position[0], 0));
            g.DrawLine(Pens.Green, new Point(0, 0), new Point((int)(0.707*position[1]), (int)(0.707*position[1])));
            g.DrawLine(Pens.Black, new Point(0, 0), new Point(0, (int)position[2]));
            g.DrawLine(Pens.Blue, new Point(0, 0), new Point((int)(-0.707*position[3]), (int)(0.707*position[3])));
            g.DrawLine(Pens.Gray, new Point(0, 0), new Point(-(int)position[4],0));
            g.DrawLine(Pens.Brown, new Point(0, 0), new Point(-(int)(0.707 * position[5]), -(int)(0.707 * position[5])));
            g.DrawLine(Pens.DarkBlue, new Point(0, 0), new Point(0,-(int)position[6]));
            g.DrawLine(Pens.Red, new Point(0, 0), new Point((int)(0.707 * position[7]), -(int)(0.707 * position[7])));
            g.DrawClosedCurve(Pens.DarkCyan, P_set);

            g.RotateTransform(-90);
            //DrawPath();//calculate the point position
            //if (path_list.Count > 2)
            //{
            //    for (int i = 1; i < path_list.Count; i++)
            //    {

            //        g.DrawLine(Pens.Yellow, new Point((int)path_list[i - 1][0], (int)path_list[i - 1][1]), new Point((int)path_list[i][0], (int)path_list[i][1]));
            //        g.DrawLine(Pens.Yellow, new Point((int)path_list[i - 1][2], (int)path_list[i - 1][3]), new Point((int)path_list[i][2], (int)path_list[i][3]));
            //        g.DrawRectangle(Pens.Red, new Rectangle((int)path_list[i][0], (int)path_list[i][1], 1, 1));
            //        g.DrawRectangle(Pens.Red, new Rectangle((int)path_list[i][2], (int)path_list[i][3], 1, 1));
            //    }
            //}
            g.TranslateTransform(-200,-200);
            Rectangle r = new Rectangle(0, 0, 400, 400);
            g.DrawRectangle(Pens.DarkBlue, new Rectangle(185, 180, 30, 40));
            g.DrawRectangle(Pens.DarkBlue, new Rectangle(198, 175, 4, 5));
            g.DrawRectangle(Pens.Red, r);
            Bitmap myBitmap = Properties.Resources.arrow;
            switch (Dir)
            {
                //up
                case "$1": myBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    g.DrawImage(myBitmap, new Rectangle(185, 100, 30, 40));
                    break;
                //left
                case "$2":
                    myBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    g.DrawImage(myBitmap, new Rectangle(110, 186, 40, 30));
                    break;
                //right
                case "$3":
                    //myBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    g.DrawImage(myBitmap, new Rectangle(290, 186, 40, 30));
                    break;
                //down
                case "$4":
                    myBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    g.DrawImage(myBitmap, new Rectangle(185, 260, 30, 40));
                    break;

            }
            label2.Text = "示数:";
            for (int i = 0; i < 8; i++)
            {
                label2.Text +=i+": " +position[i]+"; ";
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            scaleSize += 0.1f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scaleSize -= 0.1f;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                translateX = e.X - cursor_x;
                translateY = e.Y - cursor_y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            cursor_x = e.X;
            cursor_y = e.Y;
            isMouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            basicPosX += translateX;
            basicPosY += translateY;
            translateX = 0;
            translateY = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            basicPosX = 200;
            basicPosY = 200;
            scaleSize = 1.0f;

        }
        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //MessageBox.Show("滚动事件已被捕捉");
            scaleSize += e.Delta/1000f;
            //System.Drawing.Size t = pictureBox1.Size;
            //t.Width += e.Delta;
            //t.Height += e.Delta;
            //pictureBox1.Width = t.Width;
            //pictureBox1.Height = t.Height;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Location=new Point(this.Parkent.Location.X + 800, this.Location.Y);
        }  



    }
}
