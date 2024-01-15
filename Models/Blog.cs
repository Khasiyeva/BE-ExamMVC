using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ExamMVC.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
