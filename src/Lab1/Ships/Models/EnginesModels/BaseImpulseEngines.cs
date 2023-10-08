using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class BaseImpulseEngines : BaseEngines, IImpulseEngine
{
    protected const int CSpeed = 20;
    protected const int ESpeed = 30;
    protected const int CEngineFuelFlow = 10;
    protected const int EEngineFuelFlow = 25;
    public int DesignSpeed { get; protected init; }
    public int FuelUseAtStartup { get; protected init; }
    public int FuelUsePerUnitTime { get; protected init; }
}