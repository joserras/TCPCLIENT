using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prueba
{
    public partial class MyNewService : ServiceBase
    {
        public MyNewService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            //eventLog1.WriteEntry("In OnStart");
            Thread thread = new Thread(StartListening);
            thread.Start();
        }

        protected override void OnStop()
        {
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
        public void StartListening() {
            try
            {
                IPAddress ipAdress = IPAddress.Parse("127.0.0.0");
                TcpListener tcpListener = new TcpListener(IPAddress.Any, 500);
                tcpListener.Start();
                Byte[] bytes = new Byte[256];
                while (true)
                {

                    Socket socket = tcpListener.AcceptSocket();
                    ASCIIEncoding asen = new ASCIIEncoding();
                    string str = asen.GetString(bytes);
                    socket.Close();

                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}
