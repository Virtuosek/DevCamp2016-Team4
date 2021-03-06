﻿using System;
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
        private readonly IUserService _userService;

        public ActivitiesController(IActivityService activityService, IUserService userService)
        {
            _activityService = activityService;
            _userService = userService;
        }

        [AllowAnonymous]
        // GET: Activities
        public async Task<ActionResult> Index()
        {
            var activities = await _activityService.GetActivities(includeUserActivities: true);

            var viewModel = new ActivitiesIndexViewModel
            {
                Activities = activities.Select(model => model.ToViewModel<ActivityListItemViewModel>(User.Identity.GetUserId()))
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

            var activity = await _activityService.GetActivity(id.Value, true);

            if (activity == null)
            {
                return HttpNotFound();
            }

            var viewModel = activity.ToViewModel<ActivityDetailViewModel>(User.Identity.GetUserId());
            viewModel.Fill(activity);

            var subscribers = await _activityService.GetActivitySubscribers(id.Value);
            subscribers = subscribers.Where(s => s.Id != activity.UserId && s.Id != activity.DriverId).ToList();
            viewModel.Subscribers = subscribers;

            viewModel.User = _userService.GetUserById(activity.UserId);
            viewModel.Driver = _userService.GetUserById(activity.DriverId);

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
                var activity = await _activityService.GetActivity(viewModel.Id);
                activity.Title = viewModel.Title;
                activity.Description = viewModel.Description;
                activity.ShortCode = viewModel.ShortCode;

                await _activityService.EditActivity(activity);

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
