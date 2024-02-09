using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.API.Models
{
    [Table("Utilisateur")]
    public class UserModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Prénom")]
        public string? FirstName { get; set; }

        [Column("Nom de famille")]
        public string? LastName { get; set; }

        [Column("Date de naissance")]
        public DateTime DateOfBirth { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Numéro de téléphone")]
        public string? PhoneNumber { get; set; }

        [Column("Adresse postale")]
        public string? Address { get; set; }

        [Column("Mot de passe")]
        public string? Password { get; set; }

        [Column("Administrateur")]
        public bool IsAdmin { get; set; } = false;
    }
}