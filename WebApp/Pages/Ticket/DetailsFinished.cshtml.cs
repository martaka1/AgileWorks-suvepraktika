using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Ticket;

public class DetailsFinished : PageModel
{
    private readonly DAL.AppDbContext _context;

    public DetailsFinished(DAL.AppDbContext context)
    {
        _context = context;
    }

    public Domain.Ticket Ticket { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.Id == id);
        if (ticket == null)
        {
            return NotFound();
        }
        else
        {
            Ticket = ticket;
        }
        return Page();
    }
}
