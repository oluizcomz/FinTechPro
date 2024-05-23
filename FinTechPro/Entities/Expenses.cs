using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Expenses : Base
    {

        public decimal Value { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public ExpensesType ExpenseType { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }

        public bool IsOverdue { get; set; }

        [ForeignKey("Categories")]
        [Column(Order = 1)]
        public int IdCategory { get; set; }
        public virtual Categories Category { get; set; }
    
}
}
