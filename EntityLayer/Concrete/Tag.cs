using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        public string TagBody { get; set; }
        public bool TagStatus { get; set; }
        public int? PostID { get; set; }
        public virtual Post Post { get; set; }
    }
}
