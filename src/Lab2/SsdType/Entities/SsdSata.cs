using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdType.Entities;

public class SsdSata : SsdTypeBase
{
    private const string NameConst = "SsdSata";

    public SsdSata()
    {
        Name = NameConst;
    }

    public override SsdTypeBase Clone() => new SsdSata();
}