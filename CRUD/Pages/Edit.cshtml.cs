﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Pages
{
public class EditModel : PageModel
{
private readonly CRUD.Data.AppDbContext _context;
 public EditModel(CRUD.Data.AppDbContext context)
{
  _context = context;
 }
 [BindProperty]
 public Cliente Cliente { get; set; } = default!;
  public async Task<IActionResult> OnGetAsync(int? id)
{
 if (id == null)
{
return NotFound();
 }
 var cliente =  await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
 if (cliente == null)
{
  return NotFound();
}
  Cliente = cliente;
  return Page();
}

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
public async Task<IActionResult> OnPostAsync()
{
if (!ModelState.IsValid)
{
  return Page();
}
_context.Attach(Cliente).State = EntityState.Modified;
try
{
await _context.SaveChangesAsync();
 }
 catch (DbUpdateConcurrencyException)
 {
 if (!ClienteExists(Cliente.Id))
 {
 return NotFound();
 }
 else
  {
  throw;
  }
 }
 return RedirectToPage("./Index");
 }
private bool ClienteExists(int id)
{
   return _context.Clientes.Any(e => e.Id == id);
  }
 }
}