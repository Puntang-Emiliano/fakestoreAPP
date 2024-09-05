using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppFakeStore.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private readonly HttpClient _httpClient;

        public LoginViewModel()
        {
            _httpClient = new HttpClient();
            Title = "Iniciar sesion";
        }


        public async Task<bool> Login(string username, string password)
        {

            var loginUrl = "https://fakestoreapi.com/auth/login";

            var loginData = new
            {
                username = username,
                password = password
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(loginUrl, loginData); //METODO POST utilizando HttpClient en .NET para enviar datos en formato JSON a un endpoint.

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    return true;
                }
                else
                {
                    // Manejar error de autenticación
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, conexión fallida
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
