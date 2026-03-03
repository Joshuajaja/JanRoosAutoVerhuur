using System;
using System.Collections.Generic;
using System.Text;

namespace JanRoosAutoVerhuur.Models;

public class Car
{
    public string Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }
    public int Seats { get; set; }
    public bool Towbar { get; set; }
    public string Color { get; set; }
    public bool WinterTires { get; set; }
    public bool RoofboxOption { get; set; }
    public string Class { get; set; }

    public string DisplayName => $"{Brand} {Model}";
}


