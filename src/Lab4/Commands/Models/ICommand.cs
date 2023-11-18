using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public interface ICommand
{
    void Execute(Command request);
}