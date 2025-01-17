using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class debt
{
    public int Amount { get; set; }
    public string Tag { get; set; }
    public DateOnly Date { get; set; }
    public string Source { get; set; }
    public string Note { get; set; }
    public bool IsCleared { get; set; } // Optional property for debt status

    public debt(int amount, string tag, DateOnly date, string source, string note)
    {
        Amount = amount;
        Tag = tag;
        Date = date;
        Source = source;
        Note = note;
        IsCleared = false; // Default to false
    }
}