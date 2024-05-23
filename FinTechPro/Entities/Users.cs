using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Admin{ get; set; }
        public bool IsCurrentAccount { get; set; }


        [ForeignKey("Accounts")]
        [Column(Order = 1)]
        public int IdAccount { get; set; }
        public virtual Accounts Account { get; set; }
    }
}
