using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime MessageDate { get; set; }
        public bool IsDraft { get; set; }
        public bool IsRead { get; set; }
    }
}
