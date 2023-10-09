using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaMedica.Context;
using AgendaMedica.Models;

namespace AgendaMedica.UI.Web.Controllers
{
    public class PacienteController : Controller
    {
        private readonly DataContext _context;

        public PacienteController(DataContext context)
        {
            _context = context;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
              return _context.Pacientes != null ? 
                          View(await _context.Pacientes.ToListAsync()) :
                          Problem("Entity set 'DataContext.Pacientes'  is null.");
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacienteMOD = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteMOD == null)
            {
                return NotFound();
            }

            return View(pacienteMOD);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,DtNascimento,DtCadastro")] PacienteMOD pacienteMOD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteMOD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteMOD);
        }

        // GET: Paciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacienteMOD = await _context.Pacientes.FindAsync(id);
            if (pacienteMOD == null)
            {
                return NotFound();
            }
            return View(pacienteMOD);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,DtNascimento,DtCadastro")] PacienteMOD pacienteMOD)
        {
            if (id != pacienteMOD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteMOD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteMODExists(pacienteMOD.Id))
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
            return View(pacienteMOD);
        }

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacienteMOD = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteMOD == null)
            {
                return NotFound();
            }

            return View(pacienteMOD);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacientes == null)
            {
                return Problem("Entity set 'DataContext.Pacientes'  is null.");
            }
            var pacienteMOD = await _context.Pacientes.FindAsync(id);
            if (pacienteMOD != null)
            {
                _context.Pacientes.Remove(pacienteMOD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteMODExists(int id)
        {
          return (_context.Pacientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
