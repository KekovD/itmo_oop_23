using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

public record CommandRequest(IReadOnlyList<string> Body, IReadOnlyList<Flag> Flags, int PathIndex);