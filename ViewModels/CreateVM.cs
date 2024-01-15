namespace BE_ExamMVC.ViewModels
{
    public class CreateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
