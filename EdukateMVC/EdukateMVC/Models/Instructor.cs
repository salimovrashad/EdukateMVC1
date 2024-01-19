using System.Reflection.Metadata;

namespace EdukateMVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PositionId { get; set; }
        public Position? Position { get; set; }
        public string ImageURL { get; set; }
    }
}
