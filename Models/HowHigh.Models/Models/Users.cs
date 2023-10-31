using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.Models.Models
{
    [Table("users")]
    public class Users
    {
        public int id
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Pseudo is required.")]
        [Display(Name = "Pseudo")]
        public string pseudo
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string password
        {
            get;
            set;
        }
        [Display(Name = "Nom")]
        public string? nom
        {
            get;
            set;
        }
        [Display(Name = "Prenom")]
        public string? prenom
        {
            get;
            set;
        }
        [Display(Name = "Date de naissance")]
        public DateTime date_naissance
        {
            get;
            set;
        }
        [Display(Name = "Mail")]
        [EmailAddress]
        public string? mail
        {
            get;
            set;
        }
        [Display(Name = "Date de creation")]
        public DateTime date_creation
        {
            get;
            set;
        }
        [Display(Name = "Compte vérifié")]
        public bool compte_verifie
        {
            get;
            set;
        }
    }
}
