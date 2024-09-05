using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFakeStore.ViewModels
{
    public partial class DetalleUsuarioViewModel : BaseViewModel
    {
        [ObservableProperty]
        Usuarios usuario;

        public DetalleUsuarioViewModel()
        {
            Title = "Detalle de Usuario";
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }


    }
}
