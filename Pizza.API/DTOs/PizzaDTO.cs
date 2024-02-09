using System.ComponentModel.DataAnnotations;

namespace Pizza.API.Models
{
    public class PizzaDto
    {
        public int Id { get; set; }

        [Display(Name = "Nom de la pizza")]
        [Required(ErrorMessage = "Le nom de la pizza est requis.")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        public string? Nom { get; set; }

        [Display(Name = "Description de la pizza")]
        [Required(ErrorMessage = "La description de la pizza est requise.")]
        [StringLength(100, ErrorMessage = "La description ne peut pas dépasser 100 caractères.")]
        public string? Description { get; set; }

        [Display(Name = "Prix de la pizza")]
        [Required(ErrorMessage = "Le prix de la pizza est requis.")]
        [Range(0, 999.99, ErrorMessage = "Le prix doit être entre 0 et 999.99 euros.")]
        public decimal Prix { get; set; }

        [Display(Name = "Catégorie de la pizza")]
        [EnumDataType(typeof(Categorie), ErrorMessage = "Catégorie non valide.")]
        [Required(ErrorMessage = "La catégorie de la pizza est requise.")]
        public Categorie Categorie { get; set; }
    }
}