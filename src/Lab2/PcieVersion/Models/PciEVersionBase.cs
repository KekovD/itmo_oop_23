﻿using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

public abstract class PciEVersionBase : IPrototype<PciEVersionBase>
{
    public int Version { get; protected init; }

    public abstract PciEVersionBase Clone();
}