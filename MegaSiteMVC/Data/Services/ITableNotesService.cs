using MegaSiteMVC.Models;

namespace MegaSiteMVC.Data.Services
{
    public interface ITableNotesService
    {
        Task<string> GetNotesByUserIdAsync(string userId);
        Task SaveNotesAsync(string notes);
    }
}
