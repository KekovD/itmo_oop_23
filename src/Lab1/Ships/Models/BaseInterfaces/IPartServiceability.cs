namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces;

public interface IPartServiceability
{
    bool Serviceability { get; }
    void SetPartServiceability();
}