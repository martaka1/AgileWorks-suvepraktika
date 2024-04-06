namespace Domain;

public class Ticket : BaseEntity
{
    public DateTime CreatedAtDt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string? Name { get; set; }
    public required string Description { get; set; }
    public DateTime FinishedBy { get; set; }
    public bool IsDone { get; set; } = false;
}