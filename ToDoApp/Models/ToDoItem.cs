using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAPP.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="Varchar(100)")]
        public string Name { get; set; }

        public string Time { get; set; }

        public bool IsComplete { get; set; }
    }
}
