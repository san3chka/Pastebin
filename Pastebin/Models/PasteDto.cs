namespace Pastebin.Models;

public class PasteDto
{
    public string Text { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}