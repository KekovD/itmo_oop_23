using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public record Message(IRenderable Title, IRenderable Body, IImportanceLevel Importance) : IMessage
{
    public string Render()
    {
        throw new System.NotImplementedException();
    }
}