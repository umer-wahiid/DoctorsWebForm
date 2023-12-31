﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorsWebFourm.Models;

namespace DoctorsWebFourm.Controllers
{
    public class RepliesController : Controller
    {
        private readonly Context _context;

        public RepliesController(Context context)
        {
            _context = context;
        }

        // GET: Replies
        public async Task<IActionResult> Index()
        {
            var context = _context.Reply.Include(r => r.Query).Include(r => r.User);
            return View(await context.ToListAsync());
        }

        // GET: Replies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reply == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply
                .Include(r => r.Query)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReplyId == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // GET: Replies/Create
        public IActionResult Create()
        {
            ViewData["QueryId"] = new SelectList(_context.Query, "QueryId", "QueryId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Achievements");
            return View();
        }

        // POST: Replies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReplyId,QueryId,UserId,ReplyText,Timestamp")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QueryId"] = new SelectList(_context.Query, "QueryId", "QueryId", reply.QueryId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Achievements", reply.UserId);
            return View(reply);
        }

        // GET: Replies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reply == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            ViewData["QueryId"] = new SelectList(_context.Query, "QueryId", "QueryId", reply.QueryId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Achievements", reply.UserId);
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReplyId,QueryId,UserId,ReplyText,Timestamp")] Reply reply)
        {
            if (id != reply.ReplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReplyExists(reply.ReplyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["QueryId"] = new SelectList(_context.Query, "QueryId", "QueryId", reply.QueryId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Achievements", reply.UserId);
            return View(reply);
        }

        // GET: Replies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reply == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply
                .Include(r => r.Query)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReplyId == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reply == null)
            {
                return Problem("Entity set 'Context.Reply'  is null.");
            }
            var reply = await _context.Reply.FindAsync(id);
            if (reply != null)
            {
                _context.Reply.Remove(reply);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReplyExists(int id)
        {
          return (_context.Reply?.Any(e => e.ReplyId == id)).GetValueOrDefault();
        }
    }
}
