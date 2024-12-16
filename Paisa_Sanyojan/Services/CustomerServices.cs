using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Paisa_Sanyojan.Model;


namespace Paisa_Sanyojan.Services;

public class CustomerServices
{
    public class CustomerService
    {
        private const string JsonFilePath = "/Users/roshangurung/RiderProjects/Paisa_Sanyojan/Paisa_Sanyojan/Storage/customers_data.json";
        private List<Customer> _customers;

        public Customer CurrentCustomer { get; private set; }

        public CustomerService()
        {
            LoadCustomersFromJson();
        }

        public bool GetCustomerByPhoneNumber(string phoneNumber)
        {
            CurrentCustomer = _customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
            return CurrentCustomer != null;
        }

        public void CreateCustomer(string name, string phoneNumber)
        {
            var newCustomer = new Customer { Name = name, PhoneNumber = phoneNumber };
            _customers.Add(newCustomer);
            SaveCustomersToJson();
        }

        private void LoadCustomersFromJson()
        {
            if (File.Exists(JsonFilePath))
            {
                var json = File.ReadAllText(JsonFilePath);
                _customers = JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            }
            else
            {
                _customers = new List<Customer>();
            }
        }

        private void SaveCustomersToJson()
        {
            var json = JsonSerializer.Serialize(_customers);
            File.WriteAllText(JsonFilePath, json);
        }
    }
}