using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public record Command(IList<string> Body, IList<Flag> Flags);