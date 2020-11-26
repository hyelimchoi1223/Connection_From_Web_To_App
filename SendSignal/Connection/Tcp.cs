using System.Net.Sockets;
using System.Text;

namespace SendSignal.Connection
{
    public class Tcp
    {
        private TcpClient tc;
        public  Tcp(string Ip, int port)
        {
            tc = new TcpClient(Ip, port);
        }
        public bool Send(string message)
        {
            bool IsSuccess = false;
            if(tc == null)
            {
                return IsSuccess;
            }
            byte[] buff = Encoding.ASCII.GetBytes(message);
            NetworkStream stream = tc.GetStream();
            stream.Write(buff, 0, buff.Length);
            stream.Close();
            tc.Close();

            IsSuccess = true;

            return IsSuccess;
        }
    }
}
