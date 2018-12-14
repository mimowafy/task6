using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreshLifie.Data;
using FreshLifie.Models;

namespace FreshLifie.Controllers
{
    public class User_ProviderController : Controller
    {
        private readonly FreshLifieContext _context;

        public User_ProviderController(FreshLifieContext context)
        {
            _context = context;
        }

        // GET: User_Provider
        public IActionResult Index()
        {
            var freshLifieContext = _context.User_Provider.Include(u => u._providers).Include(u => u._user);
            return View( freshLifieContext.ToList());
        }

        // GET: User_Provider/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Provider =  _context.User_Provider
                .Include(u => u._providers)
                .Include(u => u._user)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user_Provider == null)
            {
                return NotFound();
            }

            return View(user_Provider);
        }

        // GET: User_Provider/Create
        public IActionResult Create()
        {
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserAddress");
            return View();
        }

        // POST: User_Provider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,ProviderID")] User_Provider user_Provider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Provider);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderName", user_Provider.ProviderID);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserAddress", user_Provider.UserId);
            return View(user_Provider);
        }

        // GET: User_Provider/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Provider =  _context.User_Provider.Find(id);
            if (user_Provider == null)
            {
                return NotFound();
            }
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderName", user_Provider.ProviderID);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserAddress", user_Provider.UserId);
            return View(user_Provider);
        }

        // POST: User_Provider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,ProviderID")] User_Provider user_Provider)
        {
            if (id != user_Provider.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Provider);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_ProviderExists(user_Provider.UserId))
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
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderName", user_Provider.ProviderID);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserAddress", user_Provider.UserId);
            return View(user_Provider);
        }

        // GET: User_Provider/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Provider =  _context.User_Provider
                .Include(u => u._providers)
                .Include(u => u._user)
                .FirstOrDefault(m => m.UserId == id);
            if (user_Provider == null)
            {
                return NotFound();
            }

            return View(user_Provider);
        }

        // POST: User_Provider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user_Provider =  _context.User_Provider.Find(id);
            _context.User_Provider.Remove(user_Provider);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool User_ProviderExists(int id)
        {
            return _context.User_Provider.Any(e => e.UserId == id);
        }
    }
}
