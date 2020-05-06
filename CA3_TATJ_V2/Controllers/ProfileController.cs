using CA3_TATJ_V2.Data;
using CA3_TATJ_V2.Models;
using CA3_TATJ_V2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _PostRepository;
        

        public ProfileController(IPostRepository PostRepository, ApplicationDbContext context)
        {
            _PostRepository = PostRepository;
            _context = context;
            
        }
        [Authorize]
        public IActionResult Index()
            {

            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = _PostRepository.allPosts;
            ViewBag.CurrenCategory = "Posts";
            return View(postListViewModel);
        }

       
        
    }
}
