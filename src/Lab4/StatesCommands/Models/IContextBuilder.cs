﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IContextBuilder
{
    IContextBuilder WithAddressParser(IAddressParser? addressParser);
    IContextBuilder WithAddress(string address);
    IContextBuilder WithDrive(string drive);
    IContextBuilder WithFlags(IList<Flag> flags);
    Context Create();
}