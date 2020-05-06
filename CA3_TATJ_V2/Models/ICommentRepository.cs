using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.Models
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> allComments { get; }
        Comment GetCommentById(int commentId);

        //IEnumerable<Comment> getCommentsByPostID(int postID);
    }
}
