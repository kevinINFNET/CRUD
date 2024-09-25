
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Pages
{
public class IndexModel : PageModel
{
private readonly CRUD.Data.AppDbContext _context;
 public IndexModel(CRUD.Data.AppDbContext context)
 {
  _context = context;
}
public IList<Cliente> Cliente { get;set; } = default!;
 public async Task OnGetAsync()
{
  Cliente = await _context.Clientes.ToListAsync();
    }
    }
}
