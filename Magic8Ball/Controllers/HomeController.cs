using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Magic8Ball.Models;
using Magic8Ball.Models.Interfaces;

namespace Magic8Ball.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMagic8Message _magic8;

        public HomeController(ILogger<HomeController> logger, IMagic8Message magic8)
        {
            _logger = logger;
            _magic8 = magic8;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _magic8.GetMagic8Message();
            return View(result);
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
    }
}
