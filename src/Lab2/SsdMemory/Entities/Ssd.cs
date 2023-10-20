using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Entities;

public class Ssd : SsdBase
{
    public Ssd(
        string name,
        SsdTypeBase connectionOption,
        int capacity,
        int maximumSpeed,
        int powerConsumption)
        : base(name, connectionOption, capacity, maximumSpeed, powerConsumption)
    {
    }

    public Ssd(IList<object> characteristics)
        : base(characteristics)
    {
    }

    public override SsdBase Clone()
    {
        return new Ssd(
            (string)Name.Clone(),
            ConnectionOption.Clone(),
            Capacity,
            MaximumSpeed,
            PowerConsumption);
    }
}