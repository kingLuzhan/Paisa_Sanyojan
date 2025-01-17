using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BisleriumCafe.Services
{
    public class LoginService
    {
        private bool _isLoggedIn = false;
        public string _currency;

        public bool IsLoggedIn => _isLoggedIn;
        public string Currency
        {
            get => _currency;
            set
            {
                _currency = value;
                NotifyStateChanged(); // Notify components about the change
            }
        }
        // Event to notify state changes
        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        // Make the LogIn method async and place it inside the class
        public async Task<bool> LogIn(string username, string password, string currencyType)
        {
            await Task.Delay(500); // Simulate network delay
            if (username == "roshan" && password == "100")
            {
                _isLoggedIn = true;
                Currency = currencyType;
                // StateHasChanged is only available in Blazor components, 
                // so you might not need it here unless you're in a component
                return true;
            }
            else
            {
                _isLoggedIn = false;
                _currency = null;
                return false;
            }
        }

        public void LogOut()
        {
            _isLoggedIn = false;
            _currency = null;
          
        }
    }
}
