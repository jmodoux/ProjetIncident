using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using projetIncident.Models;

[assembly: Xamarin.Forms.Dependency(typeof(projetIncident.Services.MockDataStore))]
namespace projetIncident.Services
{
    public class MockDataStore : IDataStore<Incident>
    {
        List<Incident> incidents;

        public MockDataStore()
        {
            incidents = new List<Incident>();
            var mockincidents = new List<Incident>
            {
                new Incident { Id = Guid.NewGuid().ToString(), Title = "First incident", Description="This is an incident description." },
                new Incident { Id = Guid.NewGuid().ToString(), Title = "Second incident", Description="This is an incident description." },
                new Incident { Id = Guid.NewGuid().ToString(), Title = "Third incident", Description="This is an incident description." },
                new Incident { Id = Guid.NewGuid().ToString(), Title = "Fourth incident", Description="This is an incident description." },
                new Incident { Id = Guid.NewGuid().ToString(), Title = "Fifth incident", Description="This is an incident description." },
                new Incident { Id = Guid.NewGuid().ToString(), Title = "Sixth incident", Description="This is an incident description." },
            };

            foreach (var incident in mockincidents)
            {
                incidents.Add(incident);
            }
        }

        public async Task<bool> AddIncidentAsync(Incident incident)
        {
            incidents.Add(incident);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateIncidentAsync(Incident incident)
        {
            var _incident = incidents.Where((Incident arg) => arg.Id == incident.Id).FirstOrDefault();
            incidents.Remove(_incident);
            incidents.Add(incident);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteIncidentAsync(Incident incident)
        {
            var _incident = incidents.Where((Incident arg) => arg.Id == incident.Id).FirstOrDefault();
            incidents.Remove(_incident);

            return await Task.FromResult(true);
        }

        public async Task<Incident> GetIncidentAsync(string id)
        {
            return await Task.FromResult(incidents.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Incident>> GetIncidentsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(incidents);
        }
    }
}