using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeBack.Data.Models;
using BeeBack.Web.Interfaces;

namespace BeeBack.Web.Services
{
    public class FakeActivityService : IActivityService
    {
        public async Task<IEnumerable<Activity>> GetActivities()
        {
            await Task.Delay(0);

            return Activities;
        }

        public async Task<Activity> GetActivity(Guid id)
        {
            await Task.Delay(0);

            return Activities.FirstOrDefault(x => x.ID == id);
        }

        public async Task AddActivity(Activity activity)
        {
            await Task.Delay(0);

            Activities.Add(activity);
        }

        public Task EditActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        private static readonly List<Activity> Activities = new List<Activity>
            {
                new Activity
                {
                    ID = Guid.NewGuid(),
                    Title = "Tennis",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new Activity
                {
                    ID = Guid.NewGuid(),
                    Title = "Basket",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new Activity
                {
                    ID = Guid.NewGuid(),
                    Title = "Piano",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new Activity
                {
                    ID = Guid.NewGuid(),
                    Title = "Scout",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new Activity
                {
                    ID = Guid.NewGuid(),
                    Title = "Cours de flute",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                },
                new Activity
                {
                    ID = Guid.NewGuid(),
                    Title = "Natation",
                    Description = "Epsum factorial non deposit quid pro quo hic escorol. Olypian quarrels et gorilla congolium sic ad nauseum."
                }
            };

        public void Dispose()
        {
            // Bah rien en fait.. OSEF !
        }
    }
}