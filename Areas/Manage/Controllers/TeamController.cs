using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication10.DAL;
using WebApplication10.Models;

namespace WebApplication10.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {

        public readonly AppDbContext _context;
        public readonly IWebHostEnvironment _environment;


        public TeamController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        

        public IActionResult Index()
        {
            return View(_context.Teams.ToList());
        }
        public IActionResult Create() 
        {
        return View();
        }
        [HttpPost]
        

        public IActionResult Create(Team team)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            string path = _environment.WebRootPath + @"\Upload\Team";
            //string path = @"C:\\Users\\ca.r215.10\\Desktop\\Huseyn\\WebApplication10\\wwwroot\\Upload\\Team\\";
            string filename = Guid.NewGuid() + team.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                team.ImgFile.CopyTo(stream);
            }
            team.ImgUrl = filename;
            _context.Teams.Add(team);   
            _context.SaveChanges();
                
                return RedirectToAction("Index");
        }
    }
}
