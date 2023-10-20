using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Entities;

public class PowerSupply : PowerSupplyBase
{
    public PowerSupply(string name, int peakLoad)
        : base(name, peakLoad)
    {
    }

    public PowerSupply(IList<object> characteristics)
        : base(characteristics)
    {
    }

    public override PowerSupplyBase Clone()
    {
        return new PowerSupply(
            (string)Name.Clone(),
            PeakLoad);
    }
}