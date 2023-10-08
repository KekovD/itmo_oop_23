using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;

public abstract class PartServiceability : IPartServiceability
{
    public bool Serviceability { get; protected set; } = true;

    public abstract void SetPartServiceability();
}