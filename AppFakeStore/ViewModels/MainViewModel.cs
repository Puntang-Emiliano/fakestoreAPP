using AppFakeStore.Views;
using CommunityToolkit.Mvvm.Input;

namespace AppFakeStore.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Title = "ITES - Demo MVVM";
    }

    [RelayCommand]
    public async Task GoToProductoLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
    }

    [RelayCommand]
    public async Task GoToAcerca()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new AcercaPage());
    }

    [RelayCommand]
    public async Task GoToUsuarios()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioViewPage());
    }


    [RelayCommand]
    public async Task Exit()
    {
        bool respuesta = await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea terminar la sesión y salir?", "Aceptar", "Cancelar");
        
        if (respuesta)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}
