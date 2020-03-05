using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSportsWebAPI.Models
{
    public class BSportsItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string Team { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(90)]
        [RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string Details { get; set; }

        [Required]
        public string Height { get; set; }

        [Required]
        public string DateofBirth { get; set; }
    }


}
