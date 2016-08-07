using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using BeeBack.Web.Interfaces;
using BeeBack.Web.ViewModels.Activities;
using Microsoft.AspNet.Identity;

namespace BeeBack.Web.Controllers
{
    [Authorize]
    public class ActivitiesController : Controller
    {
        private readonly IActivityService _activityService;
        
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [AllowAnonymous]
        // GET: Activities
        public async Task<ActionResult> Index()
        {
            var activities = await _activityService.GetActivities();

            var viewModel = new ActivitiesIndexViewModel
            {
                Activities = activities.Select(model => model.ToViewModel<ActivityListItemViewModel>())
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

            var activity = await _activityService.GetActivity(id.Value);

            if (activity == null)
            {
                return HttpNotFound();
            }

            var viewModel = activity.ToViewModel<ActivityDetailViewModel>();
            viewModel.Fill(activity);

            return View(viewModel);
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

                var model = viewModel.ToModel();
                model.UserId = User.Identity.GetUserId();

                await _activityService.AddActivity(model);

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

            var activity = await _activityService.GetActivity(id.Value);

            if (activity == null)
            {
                return HttpNotFound();
            }

            var viewModel = activity.ToViewModel<ActivityCreateEditViewModel>();

            return View("CreateEdit", viewModel);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ActivityCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = viewModel.ToModel();

                await _activityService.EditActivity(model);

                return RedirectToAction("Index");
            }
            return View("CreateEdit", viewModel);
        }

        // GET: Activities/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var activity = await _activityService.GetActivity(id.Value);

            if (activity == null)
            {
                return HttpNotFound();
            }

            var viewModel = activity.ToViewModel<ActivityViewModel>();

            return View(viewModel);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var activity = await _activityService.GetActivity(id);

            await _activityService.DeleteActivity(activity);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _activityService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
