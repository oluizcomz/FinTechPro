using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Accounts")]
    public class Accounts : Base
    {
            public int Month { get; set; }
            public int Year{ get; set; }
            public int ClosingDate { get; set; }
            public bool IsGeneratedCopy { get; set; }
            public int MonthCopy { get; set; }
            public int YearCopy { get; set; }

        
    }
}
