using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.SpaceBaseInterfaces;

public interface ITypeOfSpace
{
    ExistingTypesOfSpace TypeOfSpace { get; }
}