using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BeeBack.Web.Models;

namespace BeeBack.Web.ViewModels.Activities
{
    public interface IActivityViewModel
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string UserId { get; set; }
        bool IsSubscribed { get; set; }
    }

    public class ActivityViewModel : IActivityViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string UserId { get; set; }

        public bool IsSubscribed { get; set; }

        public string ShortCode { get; set; }

        public Activity ToModel()
        {
            return new Activity
            {
                ID = Id,
                Title = Title,
                Description = Description,
                UserId = UserId,
                ShortCode = ShortCode
            };
        }
    }

    public static class ActivityExtension
    {
        public static T ToViewModel<T>(this Activity model) where T : IActivityViewModel, new()
        {
            var viewModel = new T
            {
                Id = model.ID,
                Title = model.Title,
                Description = model.Description,
                UserId = model.UserId,
                IsSubscribed = model.UserActivities.Any(ua => ua.UserID == model.UserId)
            };

            return viewModel;
        }
    }
}