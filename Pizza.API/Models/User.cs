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
        [Required(ErrorMessage = "Prénom Manquant")] [StringLength(30, MinimumLength = 3, ErrorMessage = "Le prénom doit être compris entre 3 et 30 caractères.")]
        [RegularExpression(@"^[a-zA-ZàâäéèêëïîôöùûüÿçÀÂÄÉÈÊËÏÎÔÖÙÛÜŸÇ'\- ]+$", ErrorMessage = "Le prénom contient des caractères non valides.")]
        public string? FirstName { get; set; }

        [Column("Nom de famille")] [Display(Name = "Nom de famille")] [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nom Manquant")] [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        [RegularExpression(@"^[a-zA-ZàâäéèêëïîôöùûüÿçÀÂÄÉÈÊËÏÎÔÖÙÛÜŸÇ'\- ]+$", ErrorMessage = "Le nom contient des caractères non valides.")]
        public string? LastName { get; set; }

        [Column("Date de naissance")] [Display(Name = "Date de naissance")] [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date de naissance Manquante")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[012])-(19|20)\d\d$", ErrorMessage = "La date de naissance doit être au format JJ-MM-AAAA")]
        public DateTime DateOfBirth { get; set; }

        [Column("Email")] [Display(Name = "Email")] [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Manquant")] 
        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Email Invalide !")]
        public string? Email { get; set; }

        [Column("Numéro de téléphone")] [Display(Name = "Numéro de téléphone")] [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Numéro de téléphone Manquant")]
        [RegularExpression(@"^0[1-9](?:[\s.-]?[0-9]{2}){4}$", ErrorMessage = "Numéro de téléphone non valide")]
        public string? PhoneNumber { get; set; }

        [Column("Adresse postale")] [Display(Name = "Adresse postale")] [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Adresse postale Manquante")]
        [RegularExpression(@"^[0-9]+[,.']?[ ]?(?:[a-zA-ZàâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ]+[,.']?[ ]?)+[0-9]{5}[ ]?[a-zA-ZàâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ\s]+$", ErrorMessage = "Adresse postale non valide")]
        public string? Address { get; set; }

        [Column("Mot de passe")] [Display(Name = "Mot de passe")] [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mot de passe Manquant")]
        [RegularExpression(@"^(?=.*[a-z].*[a-z])(?=.*[A-Z].*[A-Z])(?=.*\d.*\d)(?=.*[\W_].*[\W_].*[\W_]).{8,}$", ErrorMessage = "Le mot de passe doit contenir au moins deux minuscules, deux majuscules, deux chiffres et trois caractères spéciaux.")]
        public string? Password { get; set; } 
    }
}
