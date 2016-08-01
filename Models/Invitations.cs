using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetSystem.Models
{
    public class Invitations
    {
        public int Id { get; set; }
        [Required]
        public int HouseholdId { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        public virtual Households Household { get; set; }
    }
}