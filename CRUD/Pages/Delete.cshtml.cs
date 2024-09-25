using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Pages
{
public class DeleteModel : PageModel
{
private readonly CRUD.Data.AppDbContext _context;
 public DeleteModel(CRUD.Data.AppDbContext context)
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
var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
 if (cliente == null)
 {
return NotFound();
}
 else
 {
 Cliente = cliente;
 }
return Page();
}
 public async Task<IActionResult> OnPostAsync(int? id)
{
if (id == null)
{
return NotFound();
}
 var cliente = await _context.Clientes.FindAsync(id);
  if (cliente != null)
{
Cliente = cliente;
 _context.Clientes.Remove(Cliente);
   await _context.SaveChangesAsync();
 }
return RedirectToPage("./Index");
        }
    }
}
