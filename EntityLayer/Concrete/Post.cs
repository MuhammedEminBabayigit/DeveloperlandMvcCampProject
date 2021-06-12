using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string PostHead { get; set; }
        public string PostContent { get; set; }
        public int PostViews { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime PostDate { get; set; }
        public string PostImage { get; set; }
        public int UpVote { get; set; }
        public int UnVote { get; set; }
        public bool PostStatus { get; set; }
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        //public int TagID { get; set; }
        //public virtual Tag Tag { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
