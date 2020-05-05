using CA3_TATJ_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.ViewModels
{
    public class UserPostsViewModel
    {
        public UserPostsViewModel()
        {
            postsList = new List<Post>();
        }
        public List<Post> postsList { get; set; }
        
        public string Id { get; set; }
        public Post posts { get; set; }

    }
}
