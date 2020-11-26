using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendSignal.Models;

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
        public string Send()
        {
            TcpClient tc = new TcpClient("127.0.0.1", 7000);
            string msg = "send";
            byte[] buff = Encoding.ASCII.GetBytes(msg);
            NetworkStream stream = tc.GetStream();
            stream.Write(buff, 0, buff.Length);
            stream.Close();
            tc.Close();

            return "send";
        }
        public string Stop()
        {
            TcpClient tc = new TcpClient("127.0.0.1", 7000);
            string msg = "stop";
            byte[] buff = Encoding.ASCII.GetBytes(msg);
            NetworkStream stream = tc.GetStream();
            stream.Write(buff, 0, buff.Length);
            stream.Close();
            tc.Close();

            return "stop";
        }
    }
}
