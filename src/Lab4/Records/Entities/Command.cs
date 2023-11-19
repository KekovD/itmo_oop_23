using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

public record Command(IReadOnlyList<string> Body, IReadOnlyList<Flag> Flags, int PathIndex);