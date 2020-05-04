using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA3_TATJ_V2.Data;
using CA3_TATJ_V2.Models;
using CA3_TATJ_V2.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA3_TATJ_V2.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _PostRepository;
        public PostController(IPostRepository PostRepository, ApplicationDbContext context)
        {
            _PostRepository = PostRepository;
            _context = context;
        }




        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = _PostRepository.allPosts;
            ViewBag.CurrenCategory = "Posts";
            return View(postListViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("postId,userName,postHeader,postContent,postDate")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return Redirect(nameof(List));
            }
            return View(post);
        }
    }
}
