using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projetIncident.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddIncidentAsync(T incident);
        Task<bool> UpdateIncidentAsync(T incident);
        Task<bool> DeleteIncidentAsync(T incident);
        Task<T> GetIncidentAsync(string id);
        Task<IEnumerable<T>> GetIncidentsAsync(bool forceRefresh = false);
    }
}
