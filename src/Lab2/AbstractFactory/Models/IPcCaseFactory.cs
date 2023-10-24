using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IPcCaseFactory : IFactory
{
    public IFactory CustomInstances(
        string name,
        int maximumLength,
        int maximumWidth,
        IList<FormFactorMotherboardBase> motherboardFormFactors,
        int length,
        int width,
        int height);
}