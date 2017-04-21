using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
namespace _3c_tcp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>

    public partial class MainWindow : Window
    {
        TcpListener mTCPListener;
        TcpClient mTCPClient;
        byte[] mRx;
        Form1 f1= new Form1();
        ShowLader sl = new ShowLader();
        System.Timers.Timer timer1 = new System.Timers.Timer();
        public String SendDirString = "$0";//发送给下位机的方向控制信号
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Close_Btn_Clicked(object sender, RoutedEventArgs e)
        {
            comboBox_ip_list.IsEnabled = true;
            tb_port.IsEnabled = true;
            btn_connect.IsEnabled = true;
            btn_shut.IsEnabled = false;
            mTCPListener.Stop();
        }
        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            IPAddress ipaddr;
            int nPort;
            if (!int.TryParse(tb_port.Text,out nPort))
            {
                nPort = 8080;
                tb_port.Text = Convert.ToString(nPort);
            }
            if (!IPAddress.TryParse(comboBox_ip_list.SelectedValue.ToString(), out ipaddr))
            {
                MessageBox.Show("输入的地址");
                return;
            }
            try
            {
                mTCPListener = new TcpListener(ipaddr, nPort);
                mTCPListener.Start();
                mTCPListener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, mTCPListener);
               
                comboBox_ip_list.IsEnabled = false;
                tb_port.IsEnabled = false;
                btn_connect.IsEnabled = false;
                btn_shut.IsEnabled = true;
                printLine("Server is ready,wait client connected...");
            }
            catch (Exception exc)
            {
                MessageBox.Show("连接不成功");
            }
        }
        void onCompleteAcceptTcpClient(IAsyncResult iar)
        {
            byte[] tx = new byte[512];
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            try
            {
                mTCPClient = tcpl.EndAcceptTcpClient(iar);
                DateTime datetime = DateTime.Now;
                //tx = Encoding.ASCII.GetBytes("Connect to server：" + tb_ipAddress.Text + " , Port：" + tb_port.Text + " Time:" + datetime.ToString() + Environment.NewLine);
                tx = Encoding.ASCII.GetBytes("Connect to server " + " Time " + datetime.ToString() + Environment.NewLine);
                printLine("\r\n chat start on:" + datetime.ToString());
                mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);
                tcpl.BeginAcceptTcpClient(onCompleteAcceptTcpClient, tcpl);
                mRx = new byte[512];
                mTCPClient.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadTcpClientStream,mTCPClient);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "tcp/ip", MessageBoxButton.OK);
            }
        }
        void onCompleteReadTcpClientStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountReadBytes = 0;
            string strRecv;
            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                nCountReadBytes = tcpc.GetStream().EndRead(iar);
                if (nCountReadBytes <= 0)
                {
                    printLine("Client has been disconnected.Idle for too long");
                    printLine("____________________");
                    return;
                }
                strRecv = Encoding.ASCII.GetString(mRx, 0, nCountReadBytes);
                CheckString(strRecv);
                printLine(strRecv);


                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadTcpClientStream, tcpc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A client has disconnected!", "tcp/ip", MessageBoxButton.OK);
                printLine("__________________");
            }
        }
        public double[] dir = new double[8];
        void CheckString(string strRecv)
        {
            printLine("Receive:" + strRecv);
            string Distance_Value= @"%Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?%";
            string Direction_Value = @"%XYZ(\-|\+)?\d+(\.\d+)?XYZ(\-|\+)?\d+(\.\d+)?XYZ(\-|\+)?\d+(\.\d+)?%";
            //String Lider_Value = @"[(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?,(\-|\+)?\d+(\.\d+)?]";
            String Lidar_Value = @"D(\-|\+)?\d+(\.\d+)?A(\-|\+)?\d+(\.\d+)?";
            String []lidar_layer=strRecv.Split(new char[2] { '[', ':' });
            if (lidar_layer.Length > 2)
            {

                int i = Convert.ToInt32(lidar_layer[1]);
                String []lidar_data=lidar_layer[2].Split(',');
                for (int j = 0; j < 60; j++)
                    sl.Point_list[i * 60 + j] = Convert.ToDouble(lidar_data[j]);
            }
            Regex r = new Regex(Lidar_Value,RegexOptions.IgnoreCase);
            Match m=r.Match(strRecv);
            while(m.Success){
                //for(int i=0;i<m.Groups.Count;i++){
                String Str_group = m.Groups.SyncRoot.ToString();
                if (Regex.IsMatch(Str_group,Lidar_Value))
                {
                    
                    printLine("雷达数据：" + Str_group);
                    String[] s = Str_group.Split(new char[2] { 'D', 'A' });
                    sl.Point_list[(int)Convert.ToDouble(s[2])] = Convert.ToDouble(s[1]);
                    return;
                }
                //}
                
            }
            if (Regex.IsMatch(strRecv, Distance_Value))
            {
                printLine("距离值");
                string str1 = strRecv.Split(new char[2] { '%', '%' })[1];
                string[] str2 = str1.Split(new string[1] { "Dis" }, StringSplitOptions.None);
                double[] dir = new double[8];
                for (int i = 1; i < str2.Length; i++)
                {
                    dir[i - 1] = Convert.ToDouble(str2[i])+10;
                    if (dir[i - 1] ==-1)
                    {
                        dir[i - 1] = 25;
                    }
                    else if (dir[i - 1] == -2)
                    {
                        dir[i - 1] = 160;
                    }
                }
                f1.position = dir;
                //f1.Refresh();
                Direction di = new Direction(dir, 100);

                double[] go = di.getDir();
                //for (int i = 0; i < 5; i++)
                //{
                //    sendStringtoClient("%" + (int)(go[0]*10) + "%" + (int)(go[1]*10) + "%");
                //}
                //printLine(Convert.ToString(go[0]+"_and_"+go[1]));
            }
            else if (Regex.IsMatch(strRecv, Direction_Value))
            {
                printLine("陀螺仪：" + Environment.NewLine);
            }


        }
        private void onCompleteWriteToClientStream(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "tcp/ip server", MessageBoxButton.OK);
            }
        }
        void findMyIpv4Address()
        {
            string strThisHostName = string.Empty;
            IPHostEntry thisHostDnsEntry = null;
            IPAddress[] allIPs = null;
            IPAddress ipv4Ret = null;
            try
            {
                strThisHostName = System.Net.Dns.GetHostName();
                printLine("Host name: " + strThisHostName);
                thisHostDnsEntry = System.Net.Dns.GetHostEntry(strThisHostName);
                allIPs = thisHostDnsEntry.AddressList;
                for (int idx = allIPs.Length - 1; idx > 0;idx-- )
                {
                    if (allIPs[idx].AddressFamily == AddressFamily.InterNetwork)
                    {
                        comboBox_ip_list.Items.Add(allIPs[idx].ToString());
                        ipv4Ret = allIPs[idx];
                    }
                }
                if (comboBox_ip_list.Items.Count > 0)
                {
                    comboBox_ip_list.SelectedValue = comboBox_ip_list.Items[comboBox_ip_list.Items.Count-1];
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("无法找到可用的IPv4地址", "!!!", MessageBoxButton.OK);

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            findMyIpv4Address();
            timer1.Interval = 200;
            timer1.Elapsed += OnTimedEvent;
            timer1.AutoReset = true;
        }
        public void printLine(String _strPrint)
        {
            tb_ConsoleOutPut.Dispatcher.Invoke(new Action<string>(doInvoke), _strPrint);
            
            //Keyboard.Focus(tb_ConsoleOutPut);
        }
        public void doInvoke(string _strPrint)
        {
            tb_ConsoleOutPut.AppendText( _strPrint + Environment.NewLine);
            tb_ConsoleOutPut.ScrollToEnd();
        }

        private void btn_send(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Send.Text))
            {
                return;
            }
            sendStringtoClient(tb_Send.Text);
            tb_Send.Clear();
        }
        private void sendStringtoClient(string str_send)
        {
            byte[] tx = new byte[512];
           
            try
            {
                if (mTCPClient != null)
                {
                    if (mTCPClient.Client.Connected)
                    {
                        //string send_message = "Server" + DateTime.Now.ToString("[h:mm:ss]") + ":" + str_send;
                        string send_message =str_send;
                        tx=Encoding.ASCII.GetBytes(send_message);
                        printLine(send_message);
                        
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);

                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "TCP/IP Server", MessageBoxButton.OK);
            }

        }
        private System.Windows.Threading.DispatcherTimer dTime = new System.Windows.Threading.DispatcherTimer();
        private void btn_direction_Control(object sender, RoutedEventArgs e)
        {
            
            if(canvas1.IsEnabled==true){
                canvas1.IsEnabled = false;
                //timer1.Enabled = false;
                Group_show.IsEnabled = true;
                Group_Connect.IsEnabled = true;
            }
            else
            {
                canvas1.IsEnabled =true;
                //timer1.Enabled = true;

                Group_show.IsEnabled = false;
                Group_Connect.IsEnabled = false;
            }
            

        }
        private void OnTimedEvent(object sourece, System.Timers.ElapsedEventArgs e)
        {
            sendStringtoClient(SendDirString);
        }

        private void listbox_ip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void show_Direction(object sender, RoutedEventArgs e)
        {
           
            f1.Show();
            //sl.Show();

        }

        private void DirControlRadio_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double Left = 80;
            double Top = 50;
            switch (e.Key)
            {
                case Key.Up:
                    Canvas.SetTop(DirControlRadio, Top - 30);
                    SendDirString = "*0%";
                    break;
                case Key.Down:
                    Canvas.SetTop(DirControlRadio, Top + 30);
                    SendDirString = "*1%";
                    break;
                case Key.Left:
                    Canvas.SetLeft(DirControlRadio, Left - 30);
                    SendDirString = "*3%";
                    break;
                case Key.Right:
                    Canvas.SetLeft(DirControlRadio, Left + 30);
                    SendDirString = "*2%";
                    break;
                case Key.LeftCtrl:
                    Canvas.SetLeft(DirControlRadio, Left + 30);
                    SendDirString = "*4%";
                    break;
            }
            sendStringtoClient(SendDirString);
            f1.Dir = SendDirString;
            //Thread.Sleep(500);

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Canvas.SetTop(DirControlRadio, 50);
            Canvas.SetLeft(DirControlRadio, 80);
            SendDirString = "0";
        }
    }
}
