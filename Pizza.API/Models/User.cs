using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Utilisateur")]
    public class User
    {
        [Column("Id")] [Display(Name = "Id")] 
        public int Id { get; set; }

        [Column("Prénom")] [Display(Name = "Prénom")] [DataType(DataType.Text)]
        public string? FirstName { get; set; }

        [Column("Nom de famille")] [Display(Name = "Nom de famille")] [DataType(DataType.Text)]
        public string? LastName { get; set; }

        [Column("Date de naissance")] [Display(Name = "Date de naissance")] [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Column("Email")] [Display(Name = "Email")] [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Column("Numéro de téléphone")] [Display(Name = "Numéro de téléphone")] [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Column("Adresse postale")] [Display(Name = "Adresse postale")] [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Column("Mot de passe")] [Display(Name = "Mot de passe")] [DataType(DataType.Password)]
        public string? Password { get; set; } 
    }
}
