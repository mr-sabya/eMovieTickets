using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services.MoviesService
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<MovieDropDown> GetMovieDropDownValues();

        Task AddNewMovieAsync(MovieViewModel data);

        Task UpdateMovieAsync(MovieViewModel data);
    }
}
