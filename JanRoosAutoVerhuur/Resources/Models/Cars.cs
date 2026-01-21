using System;
using System.Collections.Generic;
using System.Text;

namespace JanRoosAutoVerhuur.Models;

public class Car
{
    public string CarName { get; set; }
    public string DailyRate { get; set; }
    public string CarImage { get; set; }
    public bool IsAvailable { get; set; }

    public string AvailabilityText =>
        IsAvailable ? "Available" : "Not available";

    public Color AvailabilityColor =>
        IsAvailable ? Colors.Green : Colors.Red;
}


