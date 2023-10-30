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
        [Required]
        [Display(Name = "Pseudo")]
        public string pseudo
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Password")]
        public string password
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Nom")]
        public string nom
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Prenom")]
        public string prenom
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Date de naissance")]
        public DateTime date_naissance
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Mail")]
        [EmailAddress]
        public string mail
        {
            get;
            set;
        }
        [Required]
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
