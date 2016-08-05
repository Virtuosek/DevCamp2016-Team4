using System;
using System.ComponentModel.DataAnnotations;

namespace BeeBack.Web.ViewModels.Activities
{
    public class ActivityViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}