﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Ingreso_Gasto.Data;
using Control_Ingreso_Gasto.Models;

namespace Control_Ingreso_Gasto.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly AplicationDbContext _context;

        public EstudiantesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Estudiantes.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Direccion,Departamento")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiantes);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }
            return View(estudiantes);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Direccion,Departamento")] Estudiantes estudiantes)
        {
            if (id != estudiantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesExists(estudiantes.Id))
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
            return View(estudiantes);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estudiantes == null)
            {
                return Problem("Entity set 'AplicationDbContext.Estudiantes'  is null.");
            }
            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes != null)
            {
                _context.Estudiantes.Remove(estudiantes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesExists(int id)
        {
          return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}
