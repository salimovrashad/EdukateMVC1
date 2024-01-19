using EdukateMVC.Areas.Admin.ViewModels.InstructorVM;
using EdukateMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdukateMVC.Controllers
{
    public class HomeController : Controller
    {
        EdukateDbContext _context { get; }

        public HomeController(EdukateDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructors.Select(i => new InstructorListItemVM
            {
                Id = i.Id,
                Name = i.Name,
                ImageURL = i.ImageURL,
                Position = i.Position
            }).ToListAsync());
        }
    }
}
