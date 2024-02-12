using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;
using Pizza.API.Models;
using Pizza.API.Repositories.Interfaces;

namespace Pizza.API.Repositories
{
    public class PizzaRepository : IRepository<PizzaModel>
    {
        private readonly ApplicationDbContext _context;

        public PizzaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PizzaModel>> GetAllAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<PizzaModel> GetByIdAsync(int id)
        {
            return await _context.Pizzas.FindAsync(id) ?? throw new KeyNotFoundException("Pizza not found");
        }

        public async Task AddAsync(PizzaModel entity)
        {
            _context.Pizzas.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PizzaModel entity)
        {
            _context.Pizzas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Pizzas.FindAsync(id);
            if (entity != null)
            {
                _context.Pizzas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PizzaModel>> FindAsync(System.Linq.Expressions.Expression<System.Func<PizzaModel, bool>> predicate)
        {
            return await _context.Pizzas.Where(predicate).ToListAsync();
        }
    }
}
