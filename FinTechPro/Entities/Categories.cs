using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Categories")]
    public class Categories :Base
    {
        [ForeignKey("Accounts")]
        [Column(Order = 1)]
        public int IdAccount { get; set; }
        public virtual Accounts Account { get; set; }
    }
}
