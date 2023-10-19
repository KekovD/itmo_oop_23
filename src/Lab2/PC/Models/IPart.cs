namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

public interface IPart
{
    bool PartValid { get; }
    bool WarrantyDisclaimer { get; }
    string Name { get; }
}