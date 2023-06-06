using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services.CategoryService
{
    public class CategoriesService : EntityBaseRepository<Category>, ICategoriesService
    {
        public CategoriesService(AppDbContext context) : base(context) { }
    }
}
