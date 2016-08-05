using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using BeeBack.Data.Models;
using BeeBack.Web.Interfaces;
using BeeBack.Web.Models;
using BeeBack.Web.ViewModels.Activities;

namespace BeeBack.Web.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // GET: Activities
        public async Task<ActionResult> Index()
        {
            var activities = await _activityService.GetActivityListItemViewModels();

            var viewModel = new ActivitiesIndexViewModel
            {
                Activities = activities
            };

            return View(viewModel);
        }

        // GET: Activities/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = await _db.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            var viewModel = new ActivityCreateEditViewModel();

            return View("CreateEdit", viewModel);
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ActivityCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Id = Guid.NewGuid();
                _db.Activities.Add(viewModel);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("CreateEdit", viewModel);
        }

        // GET: Activities/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = await _db.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View("CreateEdit", activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,Description")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(activity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("CreateEdit", activity);
        }

        // GET: Activities/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = await _db.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Activity activity = await _db.Activities.FindAsync(id);
            _db.Activities.Remove(activity);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
