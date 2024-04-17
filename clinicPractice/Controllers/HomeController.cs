using clinicPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //var customer = _context.Member_EmployeeLists.FirstOrDefault();
            //return View(customer);
            var viewModel = new EMPViewModel
            {
                Employees = _context.Member_EmployeeLists.ToList(),
                Members = _context.Member_MemberLists.ToList()
            };


            ViewBag.EmployeeTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "醫生", Text = "醫生" },
            new SelectListItem { Value = "護士", Text = "護士" },
            new SelectListItem { Value = "藥師", Text = "藥師" }
        };
            var employees = _context.Member_EmployeeLists.ToList();
            return View(viewModel);
           // return View(employees);
        }


        [HttpPost]
        public IActionResult emptype(EMPViewModel viewModel)
        {

            //var filteredEmployees = _context.Member_EmployeeLists
            //    .Where(e => e.Emp_Type == selectedEmployeeType)
            //    .ToList();

            var filteredEmployees = _context.Member_EmployeeLists
            .Where(e => e.Emp_Type == viewModel.SelectedEmployeeType)
            .ToList();

            var filteredMembers = _context.Member_MemberLists
                .Where(m => m.Address == viewModel.SelectedMemberType)
                .ToList();

            viewModel.Employees = filteredEmployees;
            viewModel.Members = filteredMembers;

            return View("Index", viewModel);
            //return View("Index", filteredEmployees);
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
