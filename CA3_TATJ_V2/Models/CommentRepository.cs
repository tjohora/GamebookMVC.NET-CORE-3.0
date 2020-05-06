using CA3_TATJ_V2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.Models
{
   public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IEnumerable<Comment> allComments
        {
            get
            {
                return _context.Comments;
            }
        }

        //public IEnumerable<Comment> getCommentsByPostID(int postID)
        //{
        //    {
        //        return _context.Comments.Where(c => c.postId == postID);
        //    }
        //}

        //public IEnumerable<Comment> getCommentsByPostID(int postID)
        //{
        //    {
        //         return _context.Comments.Where(c => c.postId.Equals(postID));
        //    }
        //}

        public Comment GetCommentById(int commentId)
        {
            return _context.Comments.FirstOrDefault(c => c.commentID == commentId);
        }
    }
}
