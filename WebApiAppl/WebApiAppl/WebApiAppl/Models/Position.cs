using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiAppl.Models
{
    public class Position
    {
        // 1 - manager.
        // 2 - subordinate.

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [Display(Name = "Position")]
        [MaxLength(50, ErrorMessage = "Position must be no more 50 characters long.")]
        public string PositionName { get; set; }
    }
}