using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Models;

namespace CRUD.Pages
{
public class CreateModel : PageModel
{
private readonly CRUD.Data.AppDbContext _context;
public CreateModel(CRUD.Data.AppDbContext context)
{
_context = context;
}
 public IActionResult OnGet()
{
  return Page();
}
[BindProperty]
 public Cliente Cliente { get; set; } = default!;
// For more information, see https://aka.ms/RazorPagesCRUD.
 public async Task<IActionResult> OnPostAsync()
 {
 if (!ModelState.IsValid)
{
 return Page();
}
_context.Clientes.Add(Cliente);
 await _context.SaveChangesAsync();
 return RedirectToPage("./Index");
     }
   }
}
