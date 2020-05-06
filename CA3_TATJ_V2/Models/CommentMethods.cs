using CA3_TATJ_V2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.Models
{
    public class CommentMethods
    {

        private readonly ApplicationDbContext _appDbContext;
        public List<Comment> Comments { get; set; }

        public string commentId { get; set; }

        public CommentMethods() { }

        public CommentMethods(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddComment(Comment comment)
        {
            if (comment != null)
            {
                Comment myComment = new Comment
                {
                    content = comment.content,
                    postId = comment.postId,
                    userName = comment.userName,
                    commentDate = DateTime.Now,
                };
                _appDbContext.Comments.Add(myComment);
            }

            _appDbContext.SaveChanges();
        }


    }
}
