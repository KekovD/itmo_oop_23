using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface ICaseBuilder
{
    IMotherboardBuilder WithCase(CaseBase caseBase);
}