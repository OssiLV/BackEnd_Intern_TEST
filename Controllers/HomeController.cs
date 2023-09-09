using BackEnd_Intern__TEST_.CourseContext;
using BackEnd_Intern__TEST_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BackEnd_Intern__TEST_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VnrInternShipContext _context;

        public HomeController( ILogger<HomeController> logger, VnrInternShipContext context )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index( int? id )
        {
            CoursesModel coursesModel = new CoursesModel();

            coursesModel.KhoaHocs = _context.KhoaHocs.ToList();


            coursesModel.MonHocs = _context.MonHocs.Where(x => x.KhoaHocId == id).ToList();


            return View(coursesModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}