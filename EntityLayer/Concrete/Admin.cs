using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        public string AdminFullName { get; set; }
        public string AdminNickName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
        
        //public ICollection<Post> Posts { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}
