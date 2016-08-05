using System;
using System.ComponentModel.DataAnnotations;
using BeeBack.Data.Models;

namespace BeeBack.Web.ViewModels.Activities
{
    public interface IActivityViewModel
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
    }

    public class ActivityViewModel : IActivityViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public Activity ToModel()
        {
            return new Activity
            {
                ID = Id,
                Title = Title,
                Description = Description
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
                Description = model.Description
            };

            return viewModel;
        }
    }
}