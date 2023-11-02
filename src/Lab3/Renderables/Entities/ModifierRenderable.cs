using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;

public class ModifierRenderable : IRenderable
{
    private readonly IRenderable _renderable;
    private readonly IRenderableModifier _modifier;

    public ModifierRenderable(
        IRenderable renderable,
        IRenderableModifier modifier)
    {
        _renderable = renderable;
        _modifier = modifier;
    }

    public string Render()
    {
        return _modifier.Modify(_renderable.Render());
    }
}