using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IContextBuilder
{
    IContextBuilder WithAddressParser(IAddressParser? addressParser);
    IContextBuilder WithAddress(string address);
    IContextBuilder WithDrive(string drive);
    IContextBuilder WithFlags(IList<Flag> flags);
    Context Crate();
}