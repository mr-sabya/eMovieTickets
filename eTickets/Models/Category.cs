using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 to 50 chars")]
        public string Name { get; set; }

   
        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
