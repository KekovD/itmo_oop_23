using Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Models;

public interface IConsoleModeBuilder
{
    IConsoleModeBuilder WithContext(IContext context);
    ConsoleLocalMode Crate();
}