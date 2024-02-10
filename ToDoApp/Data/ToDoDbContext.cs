using Microsoft.EntityFrameworkCore;
using ToDoAPP.Models;

namespace ToDoAPP.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions options) : base(options)
        {
                
        }

         public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
