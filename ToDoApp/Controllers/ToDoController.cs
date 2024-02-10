using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPP.Data;
using ToDoAPP.Models;

namespace ToDoAPP.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext context;
        public ToDoController(ToDoDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var toDoData = await context.ToDoItems.ToListAsync();
            return View(toDoData);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                await context.ToDoItems.AddAsync(toDoItem);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "ToDO");
            }
            return View(toDoItem);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.ToDoItems == null)
            {
                return NotFound();
            }
            var toDoData = await context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);

            if(toDoData == null)
            {
                return NotFound();
            }
            return View(toDoData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.ToDoItems == null)
            {
                return NotFound();
            }
            var toDoData = await context.ToDoItems.FindAsync(id);

            if (toDoData == null)
            {
                return NotFound();
            }
            return View(toDoData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                 context.Update(toDoItem);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "ToDO");
            }
            return View(toDoItem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.ToDoItems == null)
            {
                return NotFound();
            }
            var toDoData = await context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (toDoData == null)
            {
                return NotFound();
            }
            return View(toDoData);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var toDoData = await context.ToDoItems.FindAsync(id);
            if (toDoData != null)
            {
                context.ToDoItems.Remove(toDoData);
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "ToDo");
            
        }

    }
}
