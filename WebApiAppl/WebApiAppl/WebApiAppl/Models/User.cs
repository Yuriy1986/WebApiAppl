using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiAppl.Models
{
    public class User
    {
        public int Id { get; set; }

        public int PositionId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        [MaxLength(20, ErrorMessage = "Name must be no more 20 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Second name is required.")]
        [Display(Name = "Second name")]
        [MaxLength(20, ErrorMessage = "Second name must be no more 20 characters long.")]
        public string SecondName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email isn't valid.")]
        [MaxLength(50, ErrorMessage = "Email must be no more 50 characters long.")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"\(\d{3}\)\s\d{2,3}-\d{2}-\d{2}", ErrorMessage = "Phone number isn't valid.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        [MaxLength(100, ErrorMessage = "Address must be no more 100 characters long.")]
        public string Address { get; set; }
    }
}