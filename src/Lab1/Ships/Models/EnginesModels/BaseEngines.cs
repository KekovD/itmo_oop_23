using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class BaseEngines : EngineTypeIdentification, ICanBeLaunched, IPartWeight, IOperationalStatus
{
    public bool Running { get; protected set; }
    public bool Serviceability { get; protected set; } = true;
    public int PartWeight { get; protected init; }
}