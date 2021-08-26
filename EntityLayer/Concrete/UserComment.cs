﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserComment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
