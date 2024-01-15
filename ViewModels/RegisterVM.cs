using System.ComponentModel.DataAnnotations;

namespace BE_ExamMVC.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(64)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(64)]
        [MinLength(5)]
        public string Surname { get; set; }
        [Required]
        [MinLength(2)]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
