using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using revised_capstone6.Data;
using revised_capstone6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace revised_capstone6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> TaskList()
        {
            var model = await _context.TaskList.ToListAsync();
            return View(model);
        }
        public IActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.TaskList.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("TaskList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
