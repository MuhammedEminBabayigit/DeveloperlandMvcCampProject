using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        public string UserName { get; set; }

        public string UserMail { get; set; }

        public string Subject { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ContactDate { get; set; }
        public string Message { get; set; }
    }
}
