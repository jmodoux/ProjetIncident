using System;

using projetIncident.Models;

namespace projetIncident.ViewModels
{
    public class IncidentDetailViewModel : BaseViewModel
    {
        public Incident Incident { get; set; }
        public IncidentDetailViewModel(Incident incident = null)
        {
            Title = incident?.Title;
            Incident = incident;
        }
    }
}
