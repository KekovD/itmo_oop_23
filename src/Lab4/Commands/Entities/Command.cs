using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public record Command(IList<string> Body, IList<IFlag> Flag);