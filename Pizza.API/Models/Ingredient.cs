using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Ingrédient")]
    public class IngredientModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nom")]
        public string? Name { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("Prix")]
        public decimal Price { get; set; }

        public ICollection<PizzaModel> Pizzas { get; set; } = new List<PizzaModel>();
    }
}