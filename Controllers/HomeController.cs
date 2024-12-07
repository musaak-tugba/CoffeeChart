using Microsoft.AspNetCore.Mvc;
using CoffeeChart.Data;
using Newtonsoft.Json;

namespace CoffeeChart.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetChartData()
        {
            var data = _context.CoffeeConsumption
                .Select(c => new { c.Year, c.Consumption })
                .OrderBy(c => c.Year)
                .ToList();

            return Json(data);
        }


        public IActionResult Index()
        {
            var data = _context.CoffeeConsumption
                .Select(c => new { c.Year, c.Consumption })
                .OrderBy(c => c.Year)
                .ToList();

            ViewBag.ChartData = JsonConvert.SerializeObject(data);
            return View();
        }
    }
}
