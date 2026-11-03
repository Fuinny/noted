using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Noted.Data;
using Noted.Models;

namespace Noted.Controllers;

public class NotesController : Controller
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var notes = await _context.Notes.OrderByDescending(d => d.CreatedAt).ToListAsync();
        return View(notes);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Store(Note note)
    {
        if (!ModelState.IsValid)
        {
            var notes = await _context.Notes.OrderByDescending(d => d.CreatedAt).ToListAsync();
            return View("Index", notes);
        }

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var note = await _context.Notes.FindAsync(id);

        if (note is not null)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
