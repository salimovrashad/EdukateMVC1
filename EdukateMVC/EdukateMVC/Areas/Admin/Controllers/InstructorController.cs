using EdukateMVC.Areas.Admin.ViewModels.InstructorVM;
using EdukateMVC.Context;
using EdukateMVC.Helpers;
using EdukateMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EdukateMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InstructorController : Controller
    {
        EdukateDbContext _context { get; }

        public InstructorController(EdukateDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructors.Select(i=> new InstructorListItemVM
            {
                Id = i.Id,
                Name = i.Name,
                ImageURL = i.ImageURL,
                Position = i.Position
            }).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(InstructorCreateItemVM vm)
        {
            ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
            Instructor instructor = new Instructor()
            {
                Name = vm.Name,
                PositionId = vm.PositionId,
                ImageURL = await vm.ImageFile.SaveAsync(PathConstants.Product),
            };
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
            var item = await _context.Instructors.FindAsync(id);
            return View(new InstructorUpdateItemVM
            {
                Name = item.Name,
            });
        }
        [HttpPost]

        public async Task<IActionResult> Update(int id, InstructorUpdateItemVM vm)
        {
            ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
            var item = await _context.Instructors.FindAsync(id);
            item.ImageURL = await vm.ImageFile.SaveAsync(PathConstants.Product);
            item.Name = vm.Name;
            item.PositionId = vm.PositionId;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Instructors.FindAsync(id);
            _context.Instructors.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
