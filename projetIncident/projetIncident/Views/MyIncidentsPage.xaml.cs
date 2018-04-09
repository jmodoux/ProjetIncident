using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using projetIncident.Models;
using projetIncident.Views;
using projetIncident.ViewModels;

namespace projetIncident.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyIncidentsPage : ContentPage
    {
        MyIncidentsViewModel viewModel;

        public MyIncidentsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MyIncidentsViewModel();
        }

        async void OnIncidentSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var incident = args.SelectedItem as Incident;
            if (incident == null)
                return;

            await Navigation.PushAsync(new IncidentDetailPage(new IncidentDetailViewModel(incident)));

            // Manually deselect item.
            IncidentsListView.SelectedItem = null;
        }

        async void AddIncident_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewIncidentPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Incidents.Count == 0)
                viewModel.LoadIncidentsCommand.Execute(null);
        }
    }
}