using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TODO.Models;

namespace TODO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new TaskDbContext())
            {
                var tasks = db.Tasks.ToList();

                return View(tasks);
            }
        }

    }
}
