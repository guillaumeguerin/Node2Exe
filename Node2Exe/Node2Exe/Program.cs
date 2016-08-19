using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Node2Exe
{
    class Program
    {
        public static bool checkPort(int port)
        {
            bool isAvailable = true;

            // Evaluate current system tcp connections. This is the same information provided
            // by the netstat command line application, just in .Net strongly-typed object
            // form.  We will look through the list, and if our port we would like to use
            // in our TcpClient is occupied, we will set isAvailable to false.
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                {
                    isAvailable = false;
                    break;
                }
            }

            // At this point, if isAvailable is true, we can proceed accordingly.
            return isAvailable;
        }

        public static int getUnusedPort()
        {
            int port = 8080; //<--- Default port

            while (checkPort(port)) {
                port++;
            }

            return port;
        }

        static void Main(string[] args)
        {
            int port = getUnusedPort();
        }
    }
}
