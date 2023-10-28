using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;

public abstract class CaseBase : IPart, IPrototype<CaseBase>
{
    protected CaseBase(
        string name,
        int maximumLength,
        int maximumWidth,
        IList<FormFactorMotherboardBase> motherboardFormFactors,
        int length,
        int width,
        int height)
    {
        Name = name;
        MaximumLength = maximumLength;
        MaximumWidth = maximumWidth;
        MotherboardFormFactors = new List<FormFactorMotherboardBase>(motherboardFormFactors);
        Length = length;
        Width = width;
        Height = height;
    }

    public string Name { get; private set; }
    public int MaximumLength { get; private set; }
    public int MaximumWidth { get; protected set; }
    public IReadOnlyList<FormFactorMotherboardBase> MotherboardFormFactors { get; private set; }
    public int Length { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public abstract CaseBase Clone();
}