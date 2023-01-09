using MegaSiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaSiteMVC.Data.Services
{
    public class TableNotesService : ITableNotesService
    {
        public string ReadJson()
        {
            string root = "wwwroot/data";
            string fileName = "TableNote.json";
            var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            root,
            fileName);

            string jsonResult;

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public void WriteJson(string jsonString)
        {
            string root = "wwwroot/data";
            string fileName = "TableNote.json";
            var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            root,
            fileName);

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jsonString);
            }
        }
    }
}
