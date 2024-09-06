using System;
using AppFakeStore.ViewModels;

namespace AppFakeStore.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
        }

        private void HandleEntryFocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry entry)
            {
                
                if (entry.Text == GetPlaceholder(entry))
                {
                    entry.Text = string.Empty;
                }
            }
        }

        private void HandleEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry entry && string.IsNullOrWhiteSpace(entry.Text))
            {
               
                entry.Text = GetPlaceholder(entry);
            }
        }

        private string GetPlaceholder(Entry entry)
        {
            return entry == UsernameEntry ? "Usuario" : "***********";
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            ShowLoadingIndicator(true);

            try
            {
                string username = UsernameEntry.Text;
                string password = PasswordEntry.Text;

                bool success = await _viewModel.Login(username, password);

                if (success)
                {
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
            finally
            {
                ShowLoadingIndicator(false);
            }
        }

        private void ShowLoadingIndicator(bool show)
        {
            LoadingIndicator.IsRunning = show;
            LoadingIndicator.IsVisible = show;
        }
    }
}
