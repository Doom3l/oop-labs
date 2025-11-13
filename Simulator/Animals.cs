using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{   public uint Size { get; set; } = 3;

    private string description = "Unknown";
    private bool descriptionSet = false;

    public required string Description
    {
        get => description;
        init
        {
            if (descriptionSet) return;
            descriptionSet = true;

            if (string.IsNullOrWhiteSpace(value))
            {
                description = "Unknown";
                return;
            }

            string temp = value.Trim();

            if (temp.Length > 15)
                temp = temp.Substring(0, 15).TrimEnd();

            if (temp.Length < 3)
                temp = temp.PadRight(3, '#');

            if (char.IsLower(temp[0]))
                temp = char.ToUpper(temp[0]) + temp.Substring(1);

            description = temp;
        }
    }
public string Info => $"{Description}, <{Size}>";

}