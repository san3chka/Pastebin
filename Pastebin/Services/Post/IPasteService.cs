using Pastebin.Models;
using Persistence.Entity;

namespace Pastebin.Services.Post;

public interface IPasteService
{
    Task<Paste?> PasteAsync(PasteDto request);
}