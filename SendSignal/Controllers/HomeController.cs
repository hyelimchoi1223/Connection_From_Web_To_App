using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendSignal.Connection;
using SendSignal.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SendSignal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TcpSend(string message)
        {
            Tcp tcp = new Tcp("127.0.0.1", 7000);
            tcp.Send(message);
            return RedirectToAction("Index");
        }
        public IActionResult SocketSend(string message)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 7000);

            socket.Connect(serverEP);

            byte[] buff = Encoding.ASCII.GetBytes(message);
            socket.Send(buff);
            return RedirectToAction("Index");
        }
    }
}
