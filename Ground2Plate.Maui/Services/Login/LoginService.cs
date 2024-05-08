using System.Net.Http.Json;
using Ground2Plate.Models;

namespace Ground2Plate.Maui.Services.Login
{
    public class LoginService : ILoginService
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                _ = new User();
                var client = new HttpClient();
                string url = "https://localhost:7045/api/User/login/" + email + "/" + password;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    User? user = await response.Content.ReadFromJsonAsync<User>();
                    return await Task.FromResult(user!);
                }
                return null!;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null!;
            }
        }
    }
}
