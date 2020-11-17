using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVC_CRUD.Data;
using CoreMVC_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CoreMVC_CRUD.Controllers
{
    public class CommentsController : Controller
    {

        private readonly CrudContext _context;

        public CommentsController(CrudContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Comment.ToListAsync());
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PostComment(string author, string commentContent)
        {

            if (author == string.Empty || commentContent == string.Empty) return RedirectToAction(nameof(Index));
            if (author == null || commentContent == null) return RedirectToAction(nameof(Index));

            Comment comment = new Comment()
            {
                Author = author,
                Contents = commentContent,
                DateOfCreation = DateTime.Now
            };
            
            _context.Add(comment); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
