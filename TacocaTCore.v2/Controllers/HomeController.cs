using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacocaTCore.v2.Models;

namespace TacocaTCore.v2.Controllers
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

        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(string userWord)
        {
            var tacocatModel = new TacocaT();
            tacocatModel.UserWord = userWord;

            tacocatModel.Output = string.Join("", userWord.Reverse().ToArray());
            return RedirectToAction("Result", tacocatModel);
        }

        public IActionResult Result(TacocaT model)
        {
            return View(model);
        }

        public IActionResult Code()
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
