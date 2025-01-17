using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Services
{
    public class TransactionService
    {
        private readonly LoginService _loginService;

        public TransactionService(LoginService loginService)
        {
            _loginService = loginService;
        }

        public string GetCurrentCurrency()
        {
            return _loginService.Currency; // Access global currency
        }
    }
}
