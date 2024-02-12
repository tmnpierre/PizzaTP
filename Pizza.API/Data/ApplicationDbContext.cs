using Microsoft.EntityFrameworkCore;
using Pizza.API.Models;

namespace Pizza.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel>? Users { get; set; }
        public DbSet<PizzaModel>? Pizzas { get; set; }
        public DbSet<IngredientModel>? Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PizzaModel>()
                .HasMany(p => p.Ingredients)
                .WithMany(i => i.Pizzas);

            modelBuilder.Entity<IngredientModel>().HasData(
                new IngredientModel { Id = 1, Name = "Tomate", Description = "Tomates fraîches", Price = 1.00m },
                new IngredientModel { Id = 2, Name = "Fromage", Description = "Mozzarella fondante", Price = 2.00m },
                new IngredientModel { Id = 3, Name = "Pepperoni", Description = "Pepperoni épicé", Price = 2.50m },
                new IngredientModel { Id = 4, Name = "Jambon", Description = "Jambon de qualité supérieure", Price = 2.00m },
                new IngredientModel { Id = 5, Name = "Champignons", Description = "Champignons frais", Price = 1.50m },
                new IngredientModel { Id = 6, Name = "Olives", Description = "Olives noires", Price = 1.00m }
            );

            modelBuilder.Entity<PizzaModel>().HasData(
                new PizzaModel { Id = 1, Nom = "Margherita", Description = "Simple et classique.", Prix = 10.00m, Categorie = Categorie.PizzaClassique },
                new PizzaModel { Id = 2, Nom = "Pepperoni", Description = "Piquante avec pepperoni.", Prix = 12.00m, Categorie = Categorie.PizzaPiquante },
                new PizzaModel { Id = 3, Nom = "Quatre fromages", Description = "Riche en fromages.", Prix = 13.00m, Categorie = Categorie.PizzaClassique },
                new PizzaModel { Id = 4, Nom = "Végétarienne", Description = "Garnie de légumes frais.", Prix = 11.00m, Categorie = Categorie.PizzaVegetarienne },
                new PizzaModel { Id = 5, Nom = "Hawaïenne", Description = "Jambon et ananas.", Prix = 12.00m, Categorie = Categorie.PizzaClassique }
                new PizzaModel { Id = 6, Nom = "Calzone", Description = "Pliée et farcie, garnie de jambon, champignons et fromage.", Prix = 14.00m, Categorie = Categorie.Calzone }
            );

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), Email = "john.doe@example.com", PhoneNumber = "0123456789", Address = "123 Main St, Anytown", Password = "Password1", IsAdmin = false },
                new UserModel { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1992, 2, 2), Email = "jane.doe@example.com", PhoneNumber = "9876543210", Address = "456 Another St, Anytown", Password = "Password2", IsAdmin = false },
                new UserModel { Id = 3, FirstName = "Admin", LastName = "User", DateOfBirth = new DateTime(1985, 3, 3), Email = "admin@example.com", PhoneNumber = "1234567890", Address = "789 Admin St, Anytown", Password = "AdminPassword", IsAdmin = true }
            );
        }
    }
}
