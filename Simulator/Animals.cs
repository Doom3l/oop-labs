using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{   public uint Size { get; set; } = 3;

    private string description = "Unknown";

    public required string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 25, '#');
    }
public string Info => $"{Description}, <{Size}>";

}