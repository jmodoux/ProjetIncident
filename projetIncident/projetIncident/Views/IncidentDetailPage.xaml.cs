using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using projetIncident.Models;
using projetIncident.ViewModels;

namespace projetIncident.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncidentDetailPage : ContentPage
	{
        IncidentDetailViewModel viewModel;

        public IncidentDetailPage(IncidentDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public IncidentDetailPage()
        {
            InitializeComponent();

            var item = new Incident
            {
                Title = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new IncidentDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}