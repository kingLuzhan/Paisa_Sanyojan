using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BisleriumCafe.Model;
using Newtonsoft.Json;

public static class Management_List
{
    public static List<incomes> incomeList { get; set; } = new List<incomes>();
    public static List<expenditure> expenditureList { get; set; } = new List<expenditure>();
    public static List<debt> debtList { get; set; } = new List<debt>();

    // List of tags loaded from the file
    public static List<tg> tgs { get; set; } = LoadTagsFromFile();

    // Method to load tags from the tags.json file
    public static List<tg> LoadTagsFromFile()
    {
        string path = "C:\\Users\\user\\source\\repos\\BisleriumCafe\\tag.json"; // Path to your tags file

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<tg>>(json) ?? new List<tg>();
        }
        else
        {
            // If the file doesn't exist, return an empty list or some default tags.
            return new List<tg>();
        }
    }

    // Method to save tags to the tags.json file
    public static void SaveTagsToFile()
    {
        string path = "C:\\Users\\user\\source\\repos\\BisleriumCafe\\tag.json"; // Path to your tags file
        var json = JsonConvert.SerializeObject(tgs, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    // Method to add a new tag
    public static void AddTag(string newTag)
    {
        if (!tgs.Any(t => t.Name.Equals(newTag, StringComparison.OrdinalIgnoreCase)))
        {
            tgs.Add(new tg(newTag));
            SaveTagsToFile(); // Save to the file after adding the tag
        }
    }

    // Method to get all transactions
    public static List<Transaction> GetAllTransactions()
    {
        var transactions = new List<Transaction>();

        // Add incomes to the transaction list
        transactions.AddRange(incomeList.Select(i => new Transaction(
            i.Source,         // Passing the source from incomeList
            i.Amount,         // Passing the amount
            i.Date,           // Passing the date
            "Income",         // Type as "Income"
            i.Tag,            // Tag
            i.Note,           // Note
            false             // Assuming the debt isn't cleared for Income; adjust if needed
        )));

        // Add expenditures to the transaction list
        transactions.AddRange(expenditureList.Select(e => new Transaction(
            e.Source,         // Source from expenditureList
            e.Amount,         // Amount
            e.Date,           // Date
            "Expenditure",    // Type as "Expenditure"
            e.Tag,            // Tag
            e.Note,           // Note
            false             // Assuming not cleared for Expenditure; adjust if needed
        )));

        // Add debts to the transaction list
        transactions.AddRange(debtList.Select(d => new Transaction(
            d.Source,         // Source from debtList
            d.Amount,         // Amount
            d.Date,           // Date
            "Debt",           // Type as "Debt"
            d.Tag,            // Tag
            d.Note,           // Note
            d.IsCleared       // IsCleared property from debtList
        )));

        return transactions;
    }
}
