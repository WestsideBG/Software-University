namespace ProjectRider.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectRider.Models;
    using System.Linq;

    public class ProjectController : Controller
    {
        private readonly ProjectDbContext db;

        public ProjectController(ProjectDbContext context)
        {
            this.db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var project = db.Projects.ToList();

            return View(project);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Project project)
        {

            db.Projects.Add(project);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
          var proj = db.Projects.Where(p => p.Id == id).FirstOrDefault();

            return View(proj);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project projectModel)
        {
            db.Update(projectModel);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var proj = db.Projects.Where(p => p.Id == id).FirstOrDefault();

            return View(proj);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project projectModel)
        {
            db.Remove(projectModel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
