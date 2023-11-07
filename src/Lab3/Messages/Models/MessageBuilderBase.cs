using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public abstract class MessageBuilderBase : ITitleBuilder, IBodyBuilder, IImportanceBuilder, IMessageBuilder
{
    private string? _title;
    private string? _body;
    private int _importance;

    public IBodyBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public IImportanceBuilder WithBody(string body)
    {
        _body = body;
        return this;
    }

    public IMessageBuilder WithImportance(int importance)
    {
        _importance = importance;
        return this;
    }

    public Message Build() =>
        Create(
            _title ?? throw new BuilderNullException(nameof(_title)),
            _body ?? throw new BuilderNullException(nameof(_body)),
            _importance);

    protected abstract Message Create(
        string title,
        string body,
        int importance);
}