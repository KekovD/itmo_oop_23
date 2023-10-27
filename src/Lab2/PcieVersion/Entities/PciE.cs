using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;

public class PciE : PciEVersionBase
{
    public PciE(string name)
    {
        Name = name;
    }

    public override PciEVersionBase Clone()
    {
        if (Name is null)
            throw new CloneNullException(nameof(PciE));

        return new PciE((string)Name.Clone());
    }
}