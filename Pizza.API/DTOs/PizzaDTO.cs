using System.ComponentModel.DataAnnotations;

namespace Pizza.API.Models
{
    public class PizzaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la pizza est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "La description de la pizza est requise.")]
        public string? Description { get; set; }

        [Range(0, 999.99, ErrorMessage = "Le prix doit être entre 0 et 999.99 euros.")]
        public decimal Prix { get; set; }

        [EnumDataType(typeof(Categorie), ErrorMessage = "Catégorie non valide.")]
        public Categorie Categorie { get; set; }
    }
}