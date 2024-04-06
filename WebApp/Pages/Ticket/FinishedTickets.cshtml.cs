using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Ticket;

public class FinishedTickets : PageModel
{
        private readonly DAL.AppDbContext _context;

        public FinishedTickets(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Domain.Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ticket = await _context.Tickets
                .OrderByDescending(t => t.FinishedBy) 
                .ToListAsync();
        }
}