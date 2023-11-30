namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IAddressParser
{
    string GetAbsolutePath(string path);
    string CombinePath(string directory, string path);
    string? GetDirectory(string path);
    string GetUniqueName(string directory, string fileName);
}