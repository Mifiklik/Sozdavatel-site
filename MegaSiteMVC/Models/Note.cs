namespace MegaSiteMVC.Models
{
    public class Note
    {
        public int Id { get; set; }
        // Так как дата будет получаться из html, то она будет простой строкой
        public string Date { get; set; }
        public string NoteText { get; set; }
    }
}
