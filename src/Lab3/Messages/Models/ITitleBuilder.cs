using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface ITitleBuilder
{
    IBodyBuilder WithTitle(IRenderable title);
}