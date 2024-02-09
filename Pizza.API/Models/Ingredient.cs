using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Ingrédient")]
    public class Ingredient
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nom")]
        [Display(Name = "Nom de l'ingrédient")]
        public string? Name { get; set; }

        [Column("Description")]
        [Display(Name = "Description de l'ingredient")]
        public string? Description { get; set; }

        [Column("Prix")]
        [Display(Name = "Prix de l'ingredient")]
        public decimal Price { get; set; }
    }
}
