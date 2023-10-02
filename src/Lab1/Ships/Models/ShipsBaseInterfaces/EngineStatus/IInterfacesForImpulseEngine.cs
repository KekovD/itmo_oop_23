﻿using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

public interface IInterfacesForImpulseEngine : IDesignSpeedOfEngine, ICurrentEngineSpeed, IFuelConsumption
{
}