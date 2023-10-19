using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;

public class WithoutExtremeMemoryProfiles : ExtremeMemoryProfilesBase
{
    public override ExtremeMemoryProfilesBase Clone() => new WithoutExtremeMemoryProfiles();
}