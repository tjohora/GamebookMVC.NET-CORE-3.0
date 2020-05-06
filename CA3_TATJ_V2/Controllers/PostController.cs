using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA3_TATJ_V2.Data;
using CA3_TATJ_V2.Models;
using CA3_TATJ_V2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA3_TATJ_V2.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _PostRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public PostController(IPostRepository PostRepository, ApplicationDbContext context)
        {
            _PostRepository = PostRepository;
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = _PostRepository.allPosts;
            ViewBag.CurrenCategory = "Posts";
            return View(postListViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("postId,userName,postHeader,postContent,postDate")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return Redirect(nameof(Index));
            }
            return View(post);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(p => p.postId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Console.WriteLine("testc");
            Console.WriteLine(id);
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("postId,userName,postHeader,postContent,postDate")] Post post)
        {
            post.postId = id;
            //if (ModelState.IsValid)
            if (true)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                Console.WriteLine("Done!");
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("Not Done!");
            return View(post);
        }

        public ActionResult getUserPosts()
        {
            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = _PostRepository.allPosts;
            ViewBag.CurrenCategory = "Posts";
            return View(postListViewModel);
        }

        public IActionResult Search(string id)
        {

            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = _PostRepository.GetPostsBySearch(id);
            Console.WriteLine(id);
            Console.WriteLine("Test");
            Console.WriteLine(postListViewModel.Posts.Count());
            ViewBag.CurrenCategory = "Posts";
            return View(postListViewModel);
        }

    }
}
