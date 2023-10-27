using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.Models.Models
{
    [Table("throws_histories")]
    public class ThrowHistories
    {
        public int id
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "id_user")]
        public int id_user
        {
            get;
            set;
        }
        [Display(Name = "id_concours")]
        public int? id_concours
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "High")]
        public float high
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Throw date")]
        public DateTime throw_date
        {
            get;
            set;
        }
    }
}
