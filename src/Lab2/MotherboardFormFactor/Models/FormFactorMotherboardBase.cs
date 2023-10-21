using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

public abstract class FormFactorMotherboardBase : IPrototype<FormFactorMotherboardBase>
{
    public string? Name { get; protected set; }
    public int SideFirst { get; protected set; }
    public int SideSecond { get; protected set; }

    public abstract FormFactorMotherboardBase Clone();

    public abstract bool CompareFormFactor(FormFactorMotherboardBase formFactor);
}