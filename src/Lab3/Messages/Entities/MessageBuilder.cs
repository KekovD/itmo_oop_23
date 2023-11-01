using Itmo.ObjectOrientedProgramming.Lab3.LabException;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public class MessageBuilder : ITitleBuilder, IBodyBuilder, IImportanceBuilder, IMessageBuilder
{
    private IRenderable? _title;
    private IRenderable? _body;
    private IImportanceLevel? _importance;

    public IBodyBuilder WithTitle(IRenderable title)
    {
        _title = title;
        return this;
    }

    public IImportanceBuilder WithBody(IRenderable body)
    {
        _body = body;
        return this;
    }

    public IMessageBuilder WithImportance(IImportanceLevel importance)
    {
        _importance = importance;
        return this;
    }

    public IMessageBuilder ChangeTitle(IRenderable title)
    {
        _title = title;
        return this;
    }

    public IMessageBuilder ChangeBody(IRenderable body)
    {
        _body = body;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _title ?? throw new BuilderNullException(nameof(_title)),
            _body ?? throw new BuilderNullException(nameof(_body)),
            _importance ?? throw new BuilderNullException(nameof(_importance)));
    }
}