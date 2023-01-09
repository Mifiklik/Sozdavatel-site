using System.ComponentModel.DataAnnotations;

namespace MegaSiteMVC.Models
{
    public class Note
    {
        // Сейчас заметки для всех аккаунтов общие, но в дальнейшем ID позволит доставать заметки из БД
        // Для этого потребуется ещё модель таблицы со списком заметок
        //[Key]
        public int Id { get; set; }

        // Так как дата будет получаться из html, то она будет простой строкой
        public string Date { get; set; }

        [DataType(DataType.MultilineText)]
        public string NoteText { get; set; }
    }
}
