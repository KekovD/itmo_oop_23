using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;

public abstract class MotherboardBase : IPart
{
    public bool PartValid { get; protected set; } = true;
    public bool WarrantyDisclaimer { get; protected set; }
    public string Name { get; protected set; }
    public SocketBase Socket { get; protected set; }
    public int PciENumber { get; protected set; }
    public int SataNumber { get; protected set; }
    public int MemoryFrequencies { get; protected set; }
    public ExtremeMemoryProfilesBase extremeMemoryProfiles { get; protected set; }
}