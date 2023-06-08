using eTickets.Models;

namespace eTickets.Data.ViewModels
{
    public class MovieDropDown
    {
        public MovieDropDown() 
        {
            Producers = new List<Producer>();
            Categories = new List<Category>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Category> Categories { get; set; } 
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
