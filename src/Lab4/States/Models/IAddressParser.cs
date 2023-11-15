using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IAddressParser
{
    string GetAddress(Command request);
    string GetDrive(Command request);
}