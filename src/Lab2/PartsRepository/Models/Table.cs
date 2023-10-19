using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public static class Table
{
    public static IReadOnlyList<IReadOnlyList<object>> Repository { get; private set; } =
        new List<IReadOnlyList<object>>();

    public static void AddList(IList<object> newItem)
    {
        var newRepository = new List<IReadOnlyList<object>>(Repository) { newItem.ToList().AsReadOnly() };
        Repository = newRepository;
    }
}