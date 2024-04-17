using clinicPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace clinicPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ClinicSysContext _context;
        public HomeController(ILogger<HomeController> logger, ClinicSysContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // return View();
            //測試是否連線成功
            var customer = _context.Member_EmployeeLists.FirstOrDefault();
            return View(customer);
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
