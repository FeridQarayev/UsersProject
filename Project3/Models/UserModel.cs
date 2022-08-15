using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project3.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter UserName")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
