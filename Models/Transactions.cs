using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetSystem.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        //categoryId must be nullable or errors will occur. not sure why
        public decimal Amount { get; set; }
        public bool  Reconciled { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }

        public DateTimeOffset TransactionDate {get;set;}
        public int AccountsId { get; set; }

        public string TransactionUserId { get; set; }
        public string UpdateUserid { get; set; }
        

        public virtual Categories Category { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual ApplicationUser TransactionUser { get; set; }
        public virtual ApplicationUser UpdateUser { get; set; }

    }
}