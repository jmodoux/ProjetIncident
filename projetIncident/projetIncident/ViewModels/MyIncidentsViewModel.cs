using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using projetIncident.Models;
using projetIncident.Views;
namespace projetIncident.ViewModels
{
    public class MyIncidentsViewModel : BaseViewModel
    {
        public ObservableCollection<Incident> Incidents { get; set; }

        public Command LoadIncidentsCommand { get; set; }

        public MyIncidentsViewModel()
        {
            Title = "Mes incidents";
            Incidents = new ObservableCollection<Incident>();
            LoadIncidentsCommand = new Command(async () => await ExecuteLoadIncidentsCommand());

            MessagingCenter.Subscribe<NewIncidentPage, Incident>(this, "AddIncident", async (obj, incident) =>
            {
                var _incident = incident as Incident;
                Incidents.Add(_incident);
                await DataStore.AddIncidentAsync(_incident);
            });
        }

        async Task ExecuteLoadIncidentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Incidents.Clear();
                var incidents = await DataStore.GetIncidentsAsync(true);
                foreach (var incident in incidents)
                {
                    Incidents.Add(incident);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}