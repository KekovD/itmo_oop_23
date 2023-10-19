using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

public class DdrBase : IPart
{
    public bool PartValid { get; protected set; } = true;
    public bool WarrantyDisclaimer { get; protected set; } = true;
    public string Name { get; protected set; }
    public int MemorySize { get; protected set; }
    
}