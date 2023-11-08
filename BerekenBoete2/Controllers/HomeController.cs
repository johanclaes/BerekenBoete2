using BerekenBoete2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BerekenBoete2.Controllers
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

        [HttpPost("Bereken")]
        public IActionResult Bereken(string snelheid)
        {
            
            int intteBetalenBedrag = 125;
            int intSnelheid;
            string teBetalenBedrag=string.Empty;


            if (int.TryParse(snelheid,out intSnelheid))
            {
                if (intSnelheid <= 50)
                {
                    teBetalenBedrag = "Proficiat, u bent een van de weinige die niet te hard rijdt!";
                }
                else
                {
                    while (intSnelheid > 50) 
                    { 
                        intteBetalenBedrag += 25;
                        intSnelheid -= 1;
                    }
                    teBetalenBedrag = "Foei, u krijgt een boete van €" + intteBetalenBedrag.ToString() ;
                }
            }
            else
            {
                teBetalenBedrag = "Gelieve numerieke waarde in te geven.";
            }


            ViewData["Resultaat"] = teBetalenBedrag;

            return View();

        }
    }
}