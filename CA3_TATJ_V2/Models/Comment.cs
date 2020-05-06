using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.Models
{
    public class Comment
    {
        public int commentID { get; set; }
        public DateTime commentDate { get; set; }
        public string content { get; set; }
        public int postId { get; set; }
        public string userName { get; set; }

        
    }
}
