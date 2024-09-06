using CommunityToolkit.Mvvm.ComponentModel;
using AppFakeStore.Models;

namespace AppFakeStore.ViewModels
{
    public partial class DetalleUsuarioViewModel : ObservableObject
    {
        private Usuarios _usuario;

        public Usuarios Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }

        public DetalleUsuarioViewModel()
        {
        }

        public void Initialize(Usuarios usuario)
        {
            Usuario = usuario;
        }
    }
}
