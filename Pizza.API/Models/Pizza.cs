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
        [Required(ErrorMessage = "Nom de la Pizza Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom de la pizza doit être compris entre 3 et 30 caractères.")]
        public string? Name { get; set; }

        [Column("Description")]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description de la Pizza Manquante")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La description de la pizza doit être comprise entre 3 et 100 caractères.")]
        public string? Description { get; set; }

        [Column("Prix")]
        [Display(Name = "Prix")]
        [Required(ErrorMessage = "Prix de la Pizza Manquant")]
        public decimal Price { get; set; }

        [Column("Aperçu")]
        [Display(Name = "Aperçu")]
        [Required(ErrorMessage = "Aperçu de la pizza Manquant")]
        public string? Overview { get; set; }

        [Column("Categorie")]
        [Display(Name = "Catégorie")]
        [Required(ErrorMessage = "Catégorie de la pizza Manquante")]
        public Categorie Categorie { get; set; }
    }

    public enum Categorie { PizzaClassique, PizzaVegetarienne, PizzaPiquante, Calzone }
}
