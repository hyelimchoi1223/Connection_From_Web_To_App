using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ReceiveSignal_Socket
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(severTcpSocket);
            thread.IsBackground = true;
            thread.Start();

            Thread.Sleep(500);

            Console.WriteLine("종료하려면 아무키나 누르세요");
            Console.ReadLine();
        }

        private static void severTcpSocket(object obj)
        {
            using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 7000);
                serverSocket.Bind(endPoint);

                serverSocket.Listen(10);

                while(true)
                {
                    Socket clientSocket = serverSocket.Accept();

                    byte[] outbuf = new byte[1024];
                    int nbytes = clientSocket.Receive(outbuf);
                    string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);
                    Console.WriteLine($"{nbytes} bytes: {output}");
                }
            }
        }
    }
}
