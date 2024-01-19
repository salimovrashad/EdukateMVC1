using EdukateMVC.Models;

namespace EdukateMVC.Areas.Admin.ViewModels.InstructorVM
{
    public class InstructorUpdateItemVM
    {
        public string Name { get; set; }
        public int PositionId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
