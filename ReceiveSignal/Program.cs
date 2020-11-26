using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ReceiveSignal_Tcp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();
            byte[] buff = new byte[1024];
            while (true)
            {
                TcpClient tc = listener.AcceptTcpClient();

                NetworkStream stream = tc.GetStream();

                byte[] outbuf = new byte[1024];
                int nbytes = stream.Read(outbuf, 0, outbuf.Length);
                string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);
                Console.WriteLine($"{nbytes} bytes: {output}");
                stream.Close();
                tc.Close();
            }
        }
    }
}
