using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;

public class expenditure
{
    public string Source { get; set; }
    public double Amount { get; set; }
    public DateOnly Date { get; set; }
    public string Tag { get; set; } // Optional tag for categorization
    public string Note { get; set; } // Optional note for additional details

    // Constructor
    public expenditure(string source, double amount, DateOnly date, string tag, string note)
    {
        Source = source;
        Amount = amount;
        Date = date;
        Tag = tag;
        Note = note;
    }
}

