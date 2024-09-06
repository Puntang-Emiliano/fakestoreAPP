using AppFakeStore.Models;
using AppFakeStore.ViewModels;
using Microsoft.Maui.Controls;

namespace AppFakeStore.Views
{
    public partial class UsuarioViewPage : ContentPage
    {
        public UsuarioViewPage()
        {
            InitializeComponent();
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Usuarios usuario)
            {
          
                await Navigation.PushAsync(new DetalleUsuarioViewPage(usuario));
            }
        }
    }
}
