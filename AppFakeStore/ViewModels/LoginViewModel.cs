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
                var response = await _httpClient.PostAsJsonAsync(loginUrl, loginData); 

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    return true;
                }
                else
                {
                   
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
