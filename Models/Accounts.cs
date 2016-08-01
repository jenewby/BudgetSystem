using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetSystem.Models
{
    public class Accounts
    {
        public Accounts() {
            this.Transaction = new HashSet<Transactions>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }

        public int HouseholdId { get; set; }
        public DateTimeOffset? LastReconciledDate { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public virtual Households Household { get; set; }
        
        public virtual ICollection<Transactions> Transaction { get; set; }


    }
}