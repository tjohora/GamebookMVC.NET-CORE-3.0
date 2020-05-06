using CA3_TATJ_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.ViewModels
{
    public class CommentListViewModel
    {
        //public CommentListViewModel()
        //{
        //    PostComments = new List<string>();
        //}



        public Comment Comment { get; set; }
        public Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public CommentListViewModel()
        {
            PostComments = new List<Comment>();
        }

        public List<Comment> PostComments { get; set; }
    }
}
