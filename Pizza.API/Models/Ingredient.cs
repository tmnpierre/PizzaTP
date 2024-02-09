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
        [Required(ErrorMessage = "Nom de l'ingrédient Manquant")]
        public string? Name { get; set; }

        [Column("Description")]
        [Display(Name = "Description de l'ingredient")]
        [Required(ErrorMessage = "Description de l'ingrédient Manquante")]
        [StringLength(100, ErrorMessage = "La description ne peut pas dépasser 100 caractères.")]

        public string? Description { get; set; }

        [Column("Prix")]
        [Display(Name = "Prix de l'ingredient")]
        [Required(ErrorMessage = "Prix de l'ingredient Manquant")]
        [RegularExpression(@"^\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{0,2})?$", ErrorMessage = "Le prix n'est pas valide. Utilisez le format européen (ex: 1.234,56 ou 1234,56 pour 1234 euros et 56 centimes).")]
        public decimal Price { get; set; }
    }
}
