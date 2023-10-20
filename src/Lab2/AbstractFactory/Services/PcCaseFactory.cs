using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class PcCaseFactory : IPcCaseFactory
{
    public IPart CreateByName(string name) =>
        new PcCase(new CaseRepository().GetByName(name));

    public IPart CreateCustom(
        string name,
        int maximumLength,
        int maximumWidth,
        IList<FormFactorMotherboardBase> motherboardFormFactors,
        int length,
        int width,
        int height)
    {
        return new PcCase(name, maximumLength, maximumWidth, motherboardFormFactors, length, width, height);
    }
}