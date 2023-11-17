using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

public record Command(IList<string> Body, IList<Flag> Flags, int PathIndex);