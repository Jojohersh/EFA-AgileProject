using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Models.Box
{
    public class BoxCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string BoxName {get; set;}

        [Required]
        public int UserId {get; set;}
    }
}