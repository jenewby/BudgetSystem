using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetSystem.Models
{
    public class Households
    {
        public Households()
        {
            this.Account = new HashSet<Accounts>();
            this.Users = new HashSet<ApplicationUser>();
            this.Budget = new HashSet<Budgets>();

            //this is what allows me to use this set of tickets within this instance of the project.  icollection is the navigational property that points to this

        }
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        
        public virtual ICollection<Accounts> Account { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Budgets> Budget { get; set; } 

        
    }
}