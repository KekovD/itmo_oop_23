namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

public interface IPartServiceability
{
    bool Serviceability { get; }
    void SetPartServiceability();
}