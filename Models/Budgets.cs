using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetSystem.Models
{
    public class Budgets
    {

        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int Frequency {get;set;}

        public int HouseholdId { get; set; }
        public string AuthorUserId { get; set; }
        public string UpdateUserId { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Households Household { get; set; }
        public virtual ApplicationUser AuthorUser { get; set; }
        public virtual ApplicationUser UpdateUser { get; set; }

    }
}