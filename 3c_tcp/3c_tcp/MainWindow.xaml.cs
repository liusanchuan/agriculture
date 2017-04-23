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
    public class Sql_Environment
    {
        static Environment_dataDataContext sql_env=null;
        private Sql_Environment(){}
        public static Environment_dataDataContext Create_Environment_SqlData() {
            if (sql_env== null)
            {
                sql_env = new Environment_dataDataContext();
            }
            return sql_env;
        }
    }
    public class Latast_data {
        private  Latast_data() { }
        private static Latast_data La_d=null;
        public Double Temperature = 0;
        public Double Humi = 0;
        public String datatime = "";
        public Double CO2 = 0;
        public Double smokescope = 0;
        public Double Light = 0;
        public String WifiName = "";
        public  static Latast_data getSingleon()
        {
            if (La_d == null)
            {
                La_d = new Latast_data();
            }
            return La_d;
        }
    }



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
            String Environment_Value= @"<T(\-|\+)?\d+(\.\d+)?H(\-|\+)?\d+(\.\d+)?C(\-|\+)?\d+(\.\d+)?L(\-|\+)?\d+(\.\d+)?S(\-|\+)?\d+(\.\d+)?>";

            string Distance_Value= @"%Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?Dis(\-|\+)?\d+(\.\d+)?%";
            string Direction_Value = @"%XYZ(\-|\+)?\d+(\.\d+)?XYZ(\-|\+)?\d+(\.\d+)?XYZ(\-|\+)?\d+(\.\d+)?%";

            if (Regex.IsMatch(strRecv, Environment_Value)){
                String str1 = strRecv.Split(new char[2] { '<', '>' })[1];
                String[] data = str1.Split(new char[5] { 'T', 'H', 'C', 'L','S'});
                for (int i = 0; i < data.Length; i++) {
                    printLine(data[i]);
                }

                //记录插入到数据库中
                Env_Data E_Data = new Env_Data()
                {
                    WiFi_Name_ = "No.1",
                    DataTime_ =         DateTime.Now,
                    Temperature_ =      Convert.ToDouble(data[1]),
                    Humi_ =             Convert.ToDouble(data[2]),
                    CO2_ =              Convert.ToDouble(data[3]),
                    light =             Convert.ToDouble(data[4]),
                    smokescope_=        Convert.ToDouble(data[5])
                };
                Environment_dataDataContext sql_env = Sql_Environment.Create_Environment_SqlData();
                sql_env.Env_Data.InsertOnSubmit(E_Data);
                sql_env.SubmitChanges();

                //跟新单例莫斯的数据
                Latast_data latast_da = Latast_data.getSingleon();
                latast_da.Temperature = Convert.ToDouble(data[1]);
                latast_da.Humi = Convert.ToDouble(data[2]);
                latast_da.CO2 = Convert.ToDouble(data[3]);
                latast_da.Light = Convert.ToDouble(data[4]);
                latast_da.smokescope = Convert.ToDouble(data[5]);
                latast_da.datatime = DateTime.Now.ToString();

                           
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

            //f1.Show();
            //sl.Show();
            MainContent m = new MainContent();
            m.Show();

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
