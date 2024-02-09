using Microsoft.EntityFrameworkCore;
using Pizza.API.Models;

namespace Pizza.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel>? Users { get; set; }
        public DbSet<PizzaModel>? Pizzas { get; set; }
        public DbSet<IngredientModel>? Ingredients { get; set; }
    }
}