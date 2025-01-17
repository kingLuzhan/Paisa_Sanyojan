using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Model
{
    public class Transaction
    {
        public string Source { get; set; }
        public double Amount { get; set; }
        public DateOnly Date { get; set; }
        public string Type { get; set; }
        public string Tag { get; set; }
        public string Note { get; set; }
        public bool IsCleared { get; set; }

        // Parameterized constructor
        public Transaction(string source, double amount, DateOnly date, string type, string tag, string note, bool isCleared)
        {
            Source = source;
            Amount = amount;
            Date = date;
            Type = type;
            Tag = tag;
            Note = note;
            IsCleared = isCleared;
        }
    }
}