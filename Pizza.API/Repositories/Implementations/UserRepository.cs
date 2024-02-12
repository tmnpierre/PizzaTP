using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;
using Pizza.API.Models;
using Pizza.API.Repositories.Interfaces;

namespace Pizza.API.Repositories
{
    public class UserRepository : IRepository<UserModel>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException("User not found");
        }

        public async Task AddAsync(UserModel entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserModel entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserModel>> FindAsync(System.Linq.Expressions.Expression<System.Func<UserModel, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }
    }
}
