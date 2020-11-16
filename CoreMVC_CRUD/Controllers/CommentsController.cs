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
        public async Task<ActionResult> PostComment([Bind("Id,Contents,Author,DateOfCreation")]
            Comment comment)
        {
            comment.DateOfCreation = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
