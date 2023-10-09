namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces;

/// <summary>
/// This interface is required because it is needed in AC inheriting and non-inheriting AC PartServiceability.
/// </summary>
public interface IPartWeight
{
    int PartWeight { get; }
}