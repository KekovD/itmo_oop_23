using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IMessageBuilder
{
    IMessageBuilder ChangeTitle(IRenderable title);
    IMessageBuilder ChangeBody(IRenderable body);

    Message Build();
}