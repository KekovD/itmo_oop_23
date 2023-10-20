using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;

public class WithoutExtremeMemoryProfiles : XmpJedecBase
{
    public override XmpJedecBase Clone() => new WithoutExtremeMemoryProfiles();
}