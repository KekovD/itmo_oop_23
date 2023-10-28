using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IPcCaseFactory
{
    public IPcCaseFactory RepositoryInstances(IList<object> instances);
    public CaseBase Crate();

    public IPcCaseFactory CustomInstances(
        string name,
        int maximumLength,
        int maximumWidth,
        IList<FormFactorMotherboardBase> motherboardFormFactors,
        int length,
        int width,
        int height);
}