using Microsoft.EntityFrameworkCore;
using Pizza.API.Models;
using System.Linq.Expressions;

namespace Pizza.API.Data.Repositories
{
    public class PizzaRepository : IRepository<PizzaModel>
    {
        private readonly ApplicationDbContext _context;

        public PizzaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PizzaModel>> GetAllAsync() => await _context.Pizzas.ToListAsync();

        public async Task<PizzaModel> GetByIdAsync(int id) => await _context.Pizzas.FindAsync(id);

        public async Task AddAsync(PizzaModel entity)
        {
            await _context.Pizzas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PizzaModel entity)
        {
            _context.Pizzas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Pizzas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PizzaModel>> FindAsync(Expression<Func<PizzaModel, bool>> predicate)
            => await _context.Pizzas.Where(predicate).ToListAsync();
    }
}