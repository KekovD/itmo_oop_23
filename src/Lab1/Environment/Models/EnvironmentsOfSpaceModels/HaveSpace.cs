using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;

public abstract class HaveSpace : IHaveSpace<string>
{
    private Collection<string> _space = new Collection<string>();
    public IReadOnlyCollection<string> Space => new ReadOnlyCollection<string>(_space);
}