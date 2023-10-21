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

    protected CaseBase(IList<object> characteristics)
    {
        Name = (string)characteristics[0];
        MaximumLength = (int)characteristics[1];
        MaximumWidth = (int)characteristics[2];
        MotherboardFormFactors = (IReadOnlyList<FormFactorMotherboardBase>)characteristics[3];
        Length = (int)characteristics[4];
        Width = (int)characteristics[5];
        Height = (int)characteristics[6];
    }

    public string Name { get; private set; }
    public int MaximumLength { get; private set; }
    public int MaximumWidth { get; protected set; }
    public IReadOnlyList<FormFactorMotherboardBase> MotherboardFormFactors { get; private set; }
    public int Length { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public abstract CaseBase Clone();

    public CaseBase CloneWithNewName(string name)
    {
        CaseBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public CaseBase CloneWithNewMotherboardFormFactors(IList<FormFactorMotherboardBase> motherboardFormFactors)
    {
        CaseBase clone = Clone();
        clone.MotherboardFormFactors = new List<FormFactorMotherboardBase>(motherboardFormFactors);

        return clone;
    }

    public CaseBase CloneWithAddMotherboardFormFactor(FormFactorMotherboardBase motherboardFormFactor)
    {
        CaseBase clone = Clone();
        clone.MotherboardFormFactors = new List<FormFactorMotherboardBase>(clone.MotherboardFormFactors) { motherboardFormFactor };

        return clone;
    }

    public CaseBase CloneWithNewDimensions(int length, int width, int height, int maximumLength, int maximumWidth)
    {
        CaseBase clone = Clone();

        if (maximumLength >= length || maximumWidth >= width)
            return clone;

        clone.Length = length;
        clone.Width = width;
        clone.Height = height;
        clone.MaximumLength = maximumLength;
        clone.MaximumWidth = maximumWidth;

        return clone;
    }
}