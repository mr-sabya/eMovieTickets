using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class MovieViewModel
    {
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Desciption")]
        [Required(ErrorMessage = "Name is required")]
        public string Description { get; set; }


        [Display(Name = "Prince in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }


        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is required")]
        public string ImageURL { get; set; }


        [Display(Name = "Movie Start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }


        [Display(Name = "Movie End date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }


        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public int CategoryId { get; set; }

        //relationships
        public List<int> ActorIds { get; set; }


        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Movie roducer is required")]
        public int ProducerId { get; set; }
       
    }
}
