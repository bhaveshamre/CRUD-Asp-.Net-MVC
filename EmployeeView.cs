using System.ComponentModel.DataAnnotations;

namespace CRUD7.Models
{
    public class EmployeeView
    {
        [Required(ErrorMessage = "Full Name is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full name must only contain letters and spaces.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Contact No is Required")]
        [Phone(ErrorMessage = "Contact No must be of 10 No Only.")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Contact No must be of 10 No Only.")]
        public string contactNo { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Address must only contain letters and spaces.")]
        public string address { get; set; }
    }
}
