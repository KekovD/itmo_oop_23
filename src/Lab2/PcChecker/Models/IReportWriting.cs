using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IReportWriting
{
    public IList<BuildStatus> ReportCompilation(IList<BuildStatus> criticalErrors, IList<BuildStatus> warrantyCancellation);
}