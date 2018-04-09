using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using projetIncident.Models;

namespace projetIncident.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewIncidentPage : ContentPage
    {
        public Incident Incident { get; set; }

        public NewIncidentPage()
        {
            InitializeComponent();

            Incident = new Incident
            {
                Title = "Titre de l'incident",
                Description = "Ceci est la description d'un incident."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddIncident", Incident);
            await Navigation.PopModalAsync();
        }
    }
}