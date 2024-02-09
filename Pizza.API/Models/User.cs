using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Utilisateur")]
    public class User
    {
        [Column("Id")] [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Prénom")] [Display(Name = "Prénom")]
        public string? FirstName { get; set; }

        [Column("Nom de famille")] [Display(Name = "Nom de famille")]
        public string? LastName { get; set; }

        [Column("Date de naissance")] [Display(Name = "Date de naissance")]
        public DateTime DateOfBirth { get; set; }

        [Column("Email")] [Display(Name = "Email")]
        public string? Email { get; set; }

        [Column("Numéro de téléphone")] [Display(Name = "Numéro de téléphone")]
        public string? PhoneNumber { get; set; }

        [Column("Adresse postale")] [Display(Name = "Adresse postale")]
        public string? Address { get; set; }

        [Column("Mot de passe")] [Display(Name = "Mot de passe")]
        public string? Password { get; set; } 
    }
}
