using System.Collections.Generic;
using BeeBack.Web.Interfaces;
using BeeBack.Web.ViewModels.Activities;

namespace BeeBack.Web.Services
{
    public class FakeActivityService : IActivityService
    {
        public List<ActivityListItemViewModel> GetActivityListItemViewModels()
        {
            return new List<ActivityListItemViewModel>
            {
                new ActivityListItemViewModel
                {
                    Id = 1,
                    Name = "Tennis",
                    Icon = "football",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = 2,
                    Name = "Basket",
                    Icon = "football",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = 3,
                    Name = "Piano",
                    Icon = "mic",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = 4,
                    Name = "Scout",
                    Icon = "compas",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = 6,
                    Name = "Cours de flute",
                    Icon = "mic",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = 5,
                    Name = "Natation",
                    Icon = "football",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                }
            };
        }
    }
}