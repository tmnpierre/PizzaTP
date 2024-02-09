using System.ComponentModel.DataAnnotations;

namespace Pizza.API.Models
{
    public class IngredientDto
    {
        public int Id { get; set; }

        [Display(Name = "Nom de l'ingrédient")]
        [Required(ErrorMessage = "Nom de l'ingrédient Manquant")]
        [StringLength(30, ErrorMessage = "Le nom ne peut pas dépasser 30 caractères.")]
        public string? Name { get; set; }

        [Display(Name = "Description de l'ingrédient")]
        [Required(ErrorMessage = "Description de l'ingrédient Manquante")]
        [StringLength(100, ErrorMessage = "La description ne peut pas dépasser 100 caractères.")]
        public string? Description { get; set; }

        [Display(Name = "Prix de l'ingrédient")]
        [Required(ErrorMessage = "Prix de l'ingrédient Manquant")]
        [Range(0, 999.99, ErrorMessage = "Le prix doit être entre 0 et 999.99 euros.")]
        public decimal Price { get; set; }
    }
}