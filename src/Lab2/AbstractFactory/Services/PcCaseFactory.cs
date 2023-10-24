using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class PcCaseFactory : IPcCaseFactory
{
    private string? _name;
    private int _maximumLength;
    private int _maximumWidth;
    private IList<FormFactorMotherboardBase>? _motherboardFormFactors;
    private int _length;
    private int _width;
    private int _height;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _maximumLength = (int)instances[1];
        _maximumWidth = (int)instances[2];
        _motherboardFormFactors = (IList<FormFactorMotherboardBase>)instances[3];
        _length = (int)instances[4];
        _width = (int)instances[5];
        _height = (int)instances[6];

        return this;
    }

    public IFactory CustomInstances(
        string name,
        int maximumLength,
        int maximumWidth,
        IList<FormFactorMotherboardBase> motherboardFormFactors,
        int length,
        int width,
        int height)
    {
        _name = name;
        _maximumLength = maximumLength;
        _maximumWidth = maximumWidth;
        _motherboardFormFactors = motherboardFormFactors;
        _length = length;
        _width = width;
        _height = height;

        return this;
    }

    public IPart Crate()
    {
        return new PcCase(
            _name ?? throw new CrateNullException(nameof(PcCaseFactory)),
            _maximumLength,
            _maximumWidth,
            _motherboardFormFactors ?? throw new CrateNullException(nameof(PcCaseFactory)),
            _length,
            _width,
            _height);
    }
}