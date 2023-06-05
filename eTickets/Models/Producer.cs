using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 to 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is Required")]
        public string Bio { get; set; }

        //Relationshops
        public List<Movie> Movies { get; set;}
    }
}
