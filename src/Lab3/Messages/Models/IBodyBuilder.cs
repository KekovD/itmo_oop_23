using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IBodyBuilder
{
    IImportanceBuilder WithBody(IRenderable body);
}