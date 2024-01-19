using EdukateMVC.Models;

namespace EdukateMVC.Areas.Admin.ViewModels.InstructorVM
{
    public class InstructorListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position? Position { get; set; }
        public string ImageURL { get; set; }
    }
}
