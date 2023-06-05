using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace eTickets.Models
{
    public class Actor : IEntityBase
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


        //Relationships
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
