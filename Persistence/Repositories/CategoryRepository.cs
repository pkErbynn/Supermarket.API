using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Supermarket.API.Persistence.Repositories
{
    public class CategoryRepository: BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context): base(context){

        }
        public async Task<IEnumerable<Category>> ListAsync(){
            // transforming the result of a query into a collection of categories.
            return await _context.Categories.ToListAsync();
        }
    }
}