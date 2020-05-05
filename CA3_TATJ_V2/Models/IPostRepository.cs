using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> allPosts { get; }
        Post GetPostById(int postId);
        IEnumerable<Post> GetPostsBySearch(String search);
    }
}
