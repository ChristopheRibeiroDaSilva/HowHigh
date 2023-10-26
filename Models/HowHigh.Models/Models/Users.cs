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
        public long id
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Pseudo")]
        public string Pseudo
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Nom")]
        public string Nom
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Prenom")]
        public string Prenom
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Date de naissance")]
        public DateTime Date_naissance
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Mail")]
        public string Mail
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Date de creation")]
        public string Date_creation
        {
            get;
            set;
        }
        [Display(Name = "")]
        public bool Compte_verifie
        {
            get;
            set;
        }
    }
}
