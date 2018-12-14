﻿using System;
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
    public class Product_TypeController : Controller
    {
        private readonly FreshLifieContext _context;

        public Product_TypeController(FreshLifieContext context)
        {
            _context = context;
        }

        // GET: Product_Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product_Type.ToListAsync());
        }

        // GET: Product_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Type = await _context.Product_Type
                .FirstOrDefaultAsync(m => m.Product_TypeId == id);
            if (product_Type == null)
            {
                return NotFound();
            }

            return View(product_Type);
        }

        // GET: Product_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_TypeId,type")] Product_Type product_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product_Type);
        }

        // GET: Product_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Type = await _context.Product_Type.FindAsync(id);
            if (product_Type == null)
            {
                return NotFound();
            }
            return View(product_Type);
        }

        // POST: Product_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_TypeId,type")] Product_Type product_Type)
        {
            if (id != product_Type.Product_TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_TypeExists(product_Type.Product_TypeId))
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
            return View(product_Type);
        }

        // GET: Product_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Type = await _context.Product_Type
                .FirstOrDefaultAsync(m => m.Product_TypeId == id);
            if (product_Type == null)
            {
                return NotFound();
            }

            return View(product_Type);
        }

        // POST: Product_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Type = await _context.Product_Type.FindAsync(id);
            _context.Product_Type.Remove(product_Type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_TypeExists(int id)
        {
            return _context.Product_Type.Any(e => e.Product_TypeId == id);
        }
    }
}
