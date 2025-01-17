using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class incomes
{
    public string Source { get; set; }
    public double Amount { get; set; }
    public DateOnly Date { get; set; }
    public string Tag { get; set; } // Optional tag for categorization
    public string Note { get; set; } // Optional note for additional details

    // Constructor to initialize the incomes object
    public incomes(double amount, string tag, DateOnly date, string note, string source)
    {
        Amount = amount;
        Tag = tag;
        Date = date;
        Note = note;
        Source = source;
    }
}
