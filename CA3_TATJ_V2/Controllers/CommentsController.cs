using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CA3_TATJ_V2.Data;
using CA3_TATJ_V2.Models;
using CA3_TATJ_V2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;

namespace CA3_TATJ_V2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommentRepository _CommentRepository;
        private readonly IPostRepository _PostRepository;
        private CommentMethods commentMethods;

        public CommentsController(IPostRepository PostRepository, ApplicationDbContext context, ICommentRepository CommentRepository)
        {
            _PostRepository = PostRepository;
            _CommentRepository = CommentRepository;
            _context = context;
        }



        //GET: Comments
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.postId = id;
            CommentListViewModel commentListViewModel = new CommentListViewModel();
            commentListViewModel.Comments = _CommentRepository.allComments.OrderByDescending(a => a.commentDate);

            ViewBag.CurrenCategory = "Comments";
            return View(await _context.Comments.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.commentID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            Post post = _PostRepository.allPosts.FirstOrDefault(p => p.postId == id);

            if (id!=null)
            {
                ViewBag.postId = id;
            }
            

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("postId,content,userName,commentDate")] Comment comment)
        {

            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Comments", action = "Index", Id = comment.postId }));
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("commentID,commentDate,content,postId,userName")] Comment comment)
        {
            if (id != comment.commentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.commentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Comments", action = "Index", Id = comment.postId }));
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.commentID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new RouteValueDictionary(
            new { controller = "Comments", action = "Index", Id = comment.postId }));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.commentID == id);
        }
    }
}
