using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
        
            return View();
        }
    }
}
