using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA3_TATJ_V2.Data;

namespace CA3_TATJ_V2.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IEnumerable<Post> allPosts
        {
            get
            {
                return _context.Posts;
            }
        }

        public Post GetPostById(int postId)
        {
            return _context.Posts.FirstOrDefault(p => p.postId == postId);
        }
    }
}
