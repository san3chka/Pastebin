namespace Persistence.Entity;

public class User
{
    public Guid Id { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public ICollection<Paste> Pastes { get; set; } = [];
}