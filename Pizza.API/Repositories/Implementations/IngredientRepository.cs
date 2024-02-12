using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;
using Pizza.API.Models;
using Pizza.API.Repositories.Interfaces;

namespace Pizza.API.Repositories
{
    public class IngredientRepository : IRepository<IngredientModel>
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredientModel>> GetAllAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<IngredientModel> GetByIdAsync(int id)
        {
            return await _context.Ingredients.FindAsync(id) ?? throw new KeyNotFoundException("Ingredient not found");
        }

        public async Task AddAsync(IngredientModel entity)
        {
            _context.Ingredients.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IngredientModel entity)
        {
            _context.Ingredients.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Ingredients.FindAsync(id);
            if (entity != null)
            {
                _context.Ingredients.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IngredientModel>> FindAsync(System.Linq.Expressions.Expression<System.Func<IngredientModel, bool>> predicate)
        {
            return await _context.Ingredients.Where(predicate).ToListAsync();
        }
    }
}
