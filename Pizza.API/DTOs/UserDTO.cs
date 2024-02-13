using Pizza.API.Validators;
using System.ComponentModel.DataAnnotations;

namespace Pizza.API.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Prénom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le prénom doit être compris entre 3 et 30 caractères.")]
        [RegularExpression(@"^[a-zA-ZàâäéèêëïîôöùûüÿçÀÂÄÉÈÊËÏÎÔÖÙÛÜŸÇ'\- ]+$", ErrorMessage = "Le prénom contient des caractères non valides.")]
        public string? FirstName { get; set; }

        [Display(Name = "Nom de famille")]
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        [RegularExpression(@"^[a-zA-ZàâäéèêëïîôöùûüÿçÀÂÄÉÈÊËÏÎÔÖÙÛÜŸÇ'\- ]+$", ErrorMessage = "Le nom contient des caractères non valides.")]
        public string? LastName { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "Date de naissance Manquante")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[012])-(19|20)\d\d$", ErrorMessage = "La date de naissance doit être au format JJ-MM-AAAA")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Manquant")]
        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Email Invalide !")]
        public string? Email { get; set; }

        [Display(Name = "Numéro de téléphone")]
        [Required(ErrorMessage = "Numéro de téléphone Manquant")]
        [RegularExpression(@"^0[1-9](?:[\s.-]?[0-9]{2}){4}$", ErrorMessage = "Numéro de téléphone non valide")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Adresse postale")]
        [Required(ErrorMessage = "Adresse postale Manquante")]
        [RegularExpression(@"^[0-9]+[,.']?[ ]?(?:[a-zA-ZàâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ]+[,.']?[ ]?)+[0-9]{5}[ ]?[a-zA-ZàâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ\s]+$", ErrorMessage = "Adresse postale non valide")]
        public string? Address { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Mot de passe Manquant")]
        [PasswordValidator]
        public string? Password { get; set; }

        [Display(Name = "Administrateur")]
        public bool IsAdmin { get; set; }
    }
}