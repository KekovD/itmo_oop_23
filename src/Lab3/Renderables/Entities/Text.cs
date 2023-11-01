using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;

public class Text : IText<Text>
{
    private readonly List<IRenderableModifier> _modifiers;
    private readonly string _content;

    public Text(string content)
    {
        _content = content;
        _modifiers = new List<IRenderableModifier>();
    }

    public Text AddModifier(IRenderableModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }

    public string Render()
    {
        return _modifiers.Aggregate(
            _content,
            (c, m) => m.Modify(c));
    }
}