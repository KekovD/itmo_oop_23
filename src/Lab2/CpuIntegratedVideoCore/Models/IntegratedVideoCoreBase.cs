﻿using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;

public abstract class IntegratedVideoCoreBase : IPrototype<IntegratedVideoCoreBase>
{
    public string? Name { get; protected init; }

    public abstract IntegratedVideoCoreBase Clone();

    public abstract bool HaveIntegratedVideoCore();
}