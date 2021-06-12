using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        public string WriterEmail { get; set; }

        public string WriterPassword { get; set; }

        public string WriterFullName { get; set; }
        public string WriterNickName { get; set; }

        public string PicturePath { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LastLogin { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; }
        public bool WriterStatus { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
