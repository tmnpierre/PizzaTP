using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Pizza")]
    public class Pizza
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nom")]
        [Display(Name = "Nom de la Pizza")]
        public string? Name { get; set; }

        [Column("Description")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Column("Prix")]
        [Display(Name = "Prix")]
        public decimal Price { get; set; }

        [Column("Aperçu")]
        [Display(Name = "Aperçu")]
        public string? Overview { get; set; }

        [Column("Categorie")]
        [Display(Name = "Catégorie")]
        public Categorie Categorie { get; set; }
    }

    public enum Categorie { PizzaClassique, PizzaVegetarienne, PizzaPiquante, Calzone}
}
