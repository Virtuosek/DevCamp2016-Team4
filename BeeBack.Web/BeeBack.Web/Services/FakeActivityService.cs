using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeBack.Web.Interfaces;
using BeeBack.Web.ViewModels.Activities;

namespace BeeBack.Web.Services
{
    public class FakeActivityService : IActivityService
    {
        public async Task<List<ActivityListItemViewModel>> GetActivityListItemViewModels()
        {
            await Task.Delay(0);

            return new List<ActivityListItemViewModel>
            {
                new ActivityListItemViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Tennis",
                    Icon = "football",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Basket",
                    Icon = "football",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Piano",
                    Icon = "mic",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Scout",
                    Icon = "compas",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Cours de flute",
                    Icon = "mic",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new ActivityListItemViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Natation",
                    Icon = "football",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                }
            };
        }
    }
}