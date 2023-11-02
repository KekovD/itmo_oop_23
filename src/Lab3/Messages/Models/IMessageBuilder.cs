using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IMessageBuilder
{
    IMessageBuilder ChangeTitleBeforeBuild(IRenderable title);

    IMessageBuilder ChangeBodyBeforeBuild(IRenderable body);

    Message Build();
}