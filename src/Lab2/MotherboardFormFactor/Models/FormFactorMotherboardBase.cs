using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

public abstract class FormFactorMotherboardBase : IPrototype<FormFactorMotherboardBase>
{
    protected FormFactorMotherboardBase(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public abstract FormFactorMotherboardBase Clone();

    public abstract bool CompareFormFactor(FormFactorMotherboardBase formFactor);
}