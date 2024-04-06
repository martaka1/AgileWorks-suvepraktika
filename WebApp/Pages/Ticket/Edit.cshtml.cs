using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Ticket
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket =  await _context.Tickets.FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            
            Ticket = ticket;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingTicket = await _context.Tickets.FirstOrDefaultAsync(m => m.Id == Ticket.Id);
            if (existingTicket == null)
            {
                return NotFound();
            }

            // Retain the original CreatedAtDt value
            var originalCreatedAt = existingTicket.CreatedAtDt;

            // Update the properties that can change
            existingTicket.Name = Ticket.Name;
            existingTicket.Description = Ticket.Description;
            existingTicket.FinishedBy = Ticket.FinishedBy;
            existingTicket.IsDone = Ticket.IsDone;

            // Restore the original CreatedAtDt value
            existingTicket.CreatedAtDt = originalCreatedAt;
            existingTicket.UpdatedAt = DateTime.Now;

            // Mark the ticket as modified
            _context.Entry(existingTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.Id))
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

        private bool TicketExists(Guid id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
