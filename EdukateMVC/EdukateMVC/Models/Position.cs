using Microsoft.Extensions.Hosting;

namespace EdukateMVC.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Instructor>? Instructors { get; }
    }
}
