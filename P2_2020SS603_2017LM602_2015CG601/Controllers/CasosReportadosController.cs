using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020SS603_2017LM602_2015CG601.Models;

namespace P2_2020SS603_2017LM602_2015CG601.Controllers
{
    public class CasosReportadosController : Controller
    {
        private readonly RegistroCovidContext _context;

        public CasosReportadosController(RegistroCovidContext context)
        {
            _context = context;
        }

        // GET: CasosReportados
        public async Task<IActionResult> Index()
        {
              return _context.CasosReportados != null ? 
                          View(await _context.CasosReportados.ToListAsync()) :
                          Problem("Entity set 'RegistroCovidContext.CasosReportados'  is null.");
        }

        // GET: CasosReportados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CasosReportados == null)
            {
                return NotFound();
            }

            var casosReportados = await _context.CasosReportados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casosReportados == null)
            {
                return NotFound();
            }

            return View(casosReportados);
        }

        // GET: CasosReportados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasosReportados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,departamento_id,genero_id,confirmados,recuperados,fallecidos")] CasosReportados casosReportados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casosReportados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casosReportados);
        }

        // GET: CasosReportados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CasosReportados == null)
            {
                return NotFound();
            }

            var casosReportados = await _context.CasosReportados.FindAsync(id);
            if (casosReportados == null)
            {
                return NotFound();
            }
            return View(casosReportados);
        }

        // POST: CasosReportados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,departamento_id,genero_id,confirmados,recuperados,fallecidos")] CasosReportados casosReportados)
        {
            if (id != casosReportados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casosReportados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasosReportadosExists(casosReportados.Id))
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
            return View(casosReportados);
        }

        // GET: CasosReportados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CasosReportados == null)
            {
                return NotFound();
            }

            var casosReportados = await _context.CasosReportados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casosReportados == null)
            {
                return NotFound();
            }

            return View(casosReportados);
        }

        // POST: CasosReportados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CasosReportados == null)
            {
                return Problem("Entity set 'RegistroCovidContext.CasosReportados'  is null.");
            }
            var casosReportados = await _context.CasosReportados.FindAsync(id);
            if (casosReportados != null)
            {
                _context.CasosReportados.Remove(casosReportados);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasosReportadosExists(int id)
        {
          return (_context.CasosReportados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
