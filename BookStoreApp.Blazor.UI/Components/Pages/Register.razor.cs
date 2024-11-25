using BookStoreApp.Blazor.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace BookStoreApp.Blazor.UI.Components.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        protected IClient _httpClient { get; set; }

        [Inject]
        protected NavigationManager _navManager { get; set; }

        protected UserDto RegistrationModel = new UserDto
        {
            Role = "User"
        };
        protected string message = string.Empty;

        protected async Task HandleRegistration()
        {
            try
            {
                await _httpClient.RegisterAsync(RegistrationModel);
                NavigateToLogin();
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode >= 200 && ex.StatusCode <= 299)
                {
                    NavigateToLogin();
                }
                message = ex.Response;
            }

        }

        private void NavigateToLogin()
        {
            _navManager.NavigateTo("/users/login");
        }
    }
}
