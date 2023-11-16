using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IAddressParser
{
    string GetAddress(Command request);
    string GetDrive(Command request);
    string GetAbsolutePath(string path);
    string GetUniqueName(string directory, string fileName);
}