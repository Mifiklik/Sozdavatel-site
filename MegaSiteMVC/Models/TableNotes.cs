using System.ComponentModel.DataAnnotations;

namespace MegaSiteMVC.Models
{
    public class TableNotes
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string JsonNotes { get; set; }
    }
}
