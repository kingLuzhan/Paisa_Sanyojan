using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Users
{

    public string Name { get; set; }

    public string Password { get; set; }

    public string Currency { get; set; }


    public int Balance { get; set; }

    public Users() { }

    public Users (string name, string password, string currency, int balance)
    {
        Name = name;
        Password = password;
        Currency = currency;
        Balance = balance;
    }
    
}
    

