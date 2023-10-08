﻿using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class BaseEngines : IPartWeight
{
    public int PartWeight { get; protected init; }
}