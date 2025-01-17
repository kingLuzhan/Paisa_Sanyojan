using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class jsonController
{
    // File paths for different JSON files
    public const string UserFile = "C:\\Users\\user\\source\\repos\\BisleriumCafe\\user.json";
    public const string IncomeFile = "C:\\Users\\user\\source\\repos\\BisleriumCafe\\income.json";
    public const string ExpensesFile = "C:\\Users\\user\\source\\repos\\BisleriumCafe\\expenditure.json";
    public const string DebtFile = "C:\\Users\\user\\source\\repos\\BisleriumCafe\\debt.json";
    public const string TagFile = "C:\\Users\\user\\source\\repos\\BisleriumCafe\\tag.json";

    // Generic method to add data to JSON file
    public static void AddDataToJSONFile<T>(T data, string filePath)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Data saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving data: " + ex.Message);
        }
    }

    // Generic method to get data from JSON file
    public static List<T> GetDataFromJsonFile<T>(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return new List<T>();
            }

            string jsonFromFile = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonFromFile) ?? new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
            return new List<T>();
        }
    }

    // Generic method to get a single object from JSON file
    public static T GetSingleObjectFromJsonFile<T>(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return default;
            }

            string jsonFromFile = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonFromFile) ?? default;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
            return default;
        }
    }

    // Specific methods for each file

    // Income data methods
    public static void AddIncomeData(List<incomes> data) => AddDataToJSONFile(data, IncomeFile);
    public static List<incomes> GetIncomeData() => GetDataFromJsonFile<incomes>(IncomeFile);

    // Expense data methods
    public static void AddExpenseData(List<expenditure> data) => AddDataToJSONFile(data, ExpensesFile);
    public static List<expenditure> GetExpenseData() => GetDataFromJsonFile<expenditure>(ExpensesFile);

    // Debt data methods
    public static void AddDebtData(List<debt> data) => AddDataToJSONFile(data, DebtFile);
    public static List<debt> GetDebtData() => GetDataFromJsonFile<debt>(DebtFile);

    // Tag data methods
    public static void AddTagData(List<tg> data) => AddDataToJSONFile(data, TagFile);
    public static List<tg> GetTagData() => GetDataFromJsonFile<tg>(TagFile);

    // User data method
    public static void AddUserData(Users data) => AddDataToJSONFile(data, UserFile);
    public static Users GetUserData() => GetSingleObjectFromJsonFile<Users>(UserFile);
}
