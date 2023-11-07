using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

public interface IText<out T> : IRenderable
    where T : IText<T>
{
    T AddModifier(IRenderableModifier modifier);
}