using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePractie.Model
{
    public class emp
    {
        [Key]
        public int id { set; get; }
        [Required]
        [MinLength(10, ErrorMessage = "Name cannot be longer than 10 characters.")]
        public string name { set; get; }
     [Range (100,200)]
        public decimal sal { set; get; }
    }
}
