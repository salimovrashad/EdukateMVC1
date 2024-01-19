using EdukateMVC.Areas.Admin.ViewModels.InstructorVM;
using EdukateMVC.Areas.Admin.ViewModels.PositionVM;
using EdukateMVC.Context;
using EdukateMVC.Helpers;
using EdukateMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EdukateMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        EdukateDbContext _context {  get; }

        public PositionController(EdukateDbContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View(_context.Positions.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(PositionCreateItemVM vm)
        {
            Position position = new Position()
            {
                Name = vm.Name,
            };
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
