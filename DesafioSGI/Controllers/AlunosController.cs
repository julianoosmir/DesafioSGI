using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioSGI.Contexto;
using DesafioSGI.Models;

namespace DesafioSGI.Controllers
{
    public class AlunosController : Controller
    {
        private readonly Context _context;

        public AlunosController(Context context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var aluno = _context.Aluno.Include(a => a.responsavel);
            return View(await aluno.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var aluno = _context.Aluno.Include(a => a.responsavel);

            var alunoDetails = await aluno
                .FirstOrDefaultAsync(m => m.alunoId == id);
            if (alunoDetails == null)
            {
                return NotFound();
            }

            return View(alunoDetails);
        }

        // GET: Alunos/Create
        public async Task<IActionResult> CreateAsync()
        {
            List<Responsavel> responsavels = await _context.responsaveis.ToListAsync();
            ViewData["responsavel"] = new SelectList(responsavels, "responsavelId","Nome");
            ViewData["responsaveis"] = responsavels;
            
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("alunoId,Nome,DataDeNacimento,cpf,numerodeCertidao,responsavelId")] Aluno aluno)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }
            
            List<Responsavel> responsavels = await _context.responsaveis.ToListAsync();
            ViewData["responsavel"] = new SelectList(responsavels, "responsavelId", "Nome");



            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("alunoId,Nome,DataDeNacimento,cpf,numerodeCertidao,responsavelId")] Aluno aluno)
        {
            if (id != aluno.alunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.alunoId))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.alunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.alunoId == id);
        }
    }
}
