using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;

public record RenderableMessage(IRenderable Title, IRenderable Body, int ImportanceLevel);