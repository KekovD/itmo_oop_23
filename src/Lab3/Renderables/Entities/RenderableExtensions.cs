﻿using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;

public static class RenderableExtensions
{
    public static IRenderable WithModifier(
        this IRenderable renderable,
        IRenderableModifier modifier)
    {
        return new ModifierRenderable(renderable, modifier);
    }
}