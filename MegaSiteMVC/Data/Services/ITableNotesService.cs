using MegaSiteMVC.Models;

namespace MegaSiteMVC.Data.Services
{
    public interface ITableNotesService
    {
        string ReadJson();
        void WriteJson(string jsonString);
    }
}
