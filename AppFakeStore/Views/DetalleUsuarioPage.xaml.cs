using AppFakeStore.Models;
using AppFakeStore.ViewModels;

namespace AppFakeStore.Views
{
    public partial class DetalleUsuarioViewPage : ContentPage
    {
        public DetalleUsuarioViewPage(Usuarios usuario)
        {
            InitializeComponent();

            var viewModel = new DetalleUsuarioViewModel();
            viewModel.Initialize(usuario);
            BindingContext = viewModel;
        }
    }
}
