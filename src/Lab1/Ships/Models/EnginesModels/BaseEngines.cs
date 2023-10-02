﻿using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class BaseEngines : EngineTypeIdentification, ICanBeLaunched
{
    public bool Running { get; protected set; }
    public bool Serviceability { get; } = true;
}