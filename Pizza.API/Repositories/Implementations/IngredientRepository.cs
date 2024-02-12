using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;
using Pizza.API.Models;
using Pizza.API.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Pizza.API.Repositories.Implementations
{
    public class IngredientRepository : IRepository<IngredientModel>
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredientModel>> GetAllAsync() => await _context.Ingredients.ToListAsync();

        public async Task<IngredientModel> GetByIdAsync(int id) => await _context.Ingredients.FindAsync(id);

        public async Task AddAsync(IngredientModel entity)
        {
            await _context.Ingredients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IngredientModel entity)
        {
            _context.Ingredients.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Ingredients.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IngredientModel>> FindAsync(Expression<Func<IngredientModel, bool>> predicate)
            => await _context.Ingredients.Where(predicate).ToListAsync();
    }
}