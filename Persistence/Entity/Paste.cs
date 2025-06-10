namespace Persistence.Entity;

public class Paste
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public User User { get; set; }
    public Guid UserId { get; set; }
}