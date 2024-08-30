using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = TaskManagementSystem.Models.Task;

namespace catering_software.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskServiceContext _context;

        public HomeController(TaskServiceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Tbl_Tasks.ToList());
        }

        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Task dtask)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_Tasks.Add(dtask);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(dtask);
        }
        public IActionResult UpdateStatus(int id)
        {
            var dtask = _context.Tbl_Tasks.Find(id);
            if (dtask == null)
            {
                return NotFound();
            }
            return View(dtask);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var dtask = _context.Tbl_Tasks.Find(id);
            if (dtask == null)
            {
                return NotFound(dtask);
            }

            dtask.Status = status;
            _context.Update(dtask);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
       
        public IActionResult DeleteTask(int id)
        {
            var dtask = _context.Tbl_Tasks.Find(id);
            if (dtask == null)
            {
                return NotFound(dtask);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string status, string assignee, DateTime? deadline)
        {
            var dtask = _context.Tbl_Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                dtask = dtask.Where(t => t.Status == status);
            }

            if (!string.IsNullOrEmpty(assignee))
            {
                dtask = dtask.Where(t => t.Assignee == assignee);
            }

            if (deadline.HasValue)
            {
                dtask = dtask.Where(t => t.Deadline.Date == deadline.Value.Date);
            }

            return View(dtask.ToList());
        }


        [HttpPost, ActionName("DeleteTask")]
        public IActionResult DeleteConfirmed(int id)
        {
            var dtask = _context.Tbl_Tasks.Find(id);
            if (dtask != null)
            {
                _context.Tbl_Tasks.Remove(dtask);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
