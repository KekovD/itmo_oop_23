using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class ReportWriting : IReportWriting
{
    public IList<BuildStatus> ReportCompilation(IList<BuildStatus> criticalErrors, IList<BuildStatus> warrantyCancellation)
    {
        var message = new List<BuildStatus>();

        if (criticalErrors.Count == 0)
        {
            message.Add(BuildStatus.Successfully);

            if (warrantyCancellation.Count != 0)
            {
                message.AddRange(warrantyCancellation);
            }

            return message;
        }

        message.AddRange(criticalErrors);

        return message;
    }
}