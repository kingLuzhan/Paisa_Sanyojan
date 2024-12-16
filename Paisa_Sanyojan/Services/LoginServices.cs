
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Paisa_Sanyojan.Model;

namespace Paisa_Sanyojan.Services
{

    public class LoginServices
    {



        private static List<Login> _staffMembers;

        public static Login CurrentUser { get; private set; }

        private const string JsonFilePath =
            "/Users/roshangurung/RiderProjects/Paisa_Sanyojan/Paisa_Sanyojan/Storage/staff_data.json";

        public LoginServices()
        {

            _staffMembers = new List<Login>();
            LoadStaffData();
        }

        public static bool Login(string username, string password)
        {
            CurrentUser = _staffMembers.FirstOrDefault(s => s.Username == username && s.Password == password);
            return CurrentUser != null;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool loginStatus()
        {
            if (CurrentUser != null)
            {
                return true;
            }

            return false;
        }

        // Method to load staff data from a JSON file
        private void LoadStaffData()
        {
            try
            {
                string json = File.ReadAllText(JsonFilePath);

                _staffMembers.AddRange(JsonSerializer.Deserialize<List<Login>>(json));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Staff data file not found. Please check the file path.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading staff data: {ex.Message}");
            }
        }

    }

}