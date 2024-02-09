using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Pizza")]
    public class Pizza
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nom")]
        public string? Name { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("Prix")]
        public decimal Price { get; set; }

        [Column("Aperçu")]
        public string? Overview { get; set; }

        [Column("Categorie")]
        public Categorie Categorie { get; set; }
    }

    public enum Categorie { PizzaClassique, PizzaVegetarienne, PizzaPiquante, Calzone}
}
