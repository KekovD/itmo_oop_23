using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public class BaseImpulseEngines : BaseEngines, IInterfacesForImpulseEngine
{
    public ImpulseEngineType ImpulseType { get; protected init; }
    public int DesignSpeed { get; protected init; }
    public int CurrentEngineSpeed { get; protected set; }
    public int FuelUseAtStartup { get; protected init; }
    public int FuelUsePerUnitTime { get; protected init; }
}