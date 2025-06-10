using Pastebin.Models;
using Persistence;
using Persistence.Entity;

namespace Pastebin.Services.Post;


public class PasteService(PastebinContext context) : IPasteService
{
    public async Task<Paste?> PasteAsync(PasteDto request)
    {
        if (request.Text.Length > 10)
        {
            return null; 
        }

        var paste = new Paste
        {
            Text = request.Text,
            UserId = request.UserId
        };

        context.Pastes.Add(paste);
        await context.SaveChangesAsync();

        return paste;
    }
}