using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Pizza")]
    public class PizzaModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nom")]
        public string? Nom { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("Prix")]
        public decimal Prix { get; set; }

        [Column("Categorie")]
        public Categorie Categorie { get; set; }

        public ICollection<IngredientModel>? Ingredients { get; set; }
    }

    public enum Categorie { PizzaClassique, PizzaVegetarienne, PizzaPiquante, Calzone }
}