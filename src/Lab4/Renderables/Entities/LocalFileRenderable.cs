using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Renderables.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;

public class LocalFileRenderable : FileRenderableSubChainLinkBase
{
    private readonly FlagLocalFileRenderableSubChainLinkBase _firstFlag;

    private LocalFileRenderable(FlagLocalFileRenderableSubChainLinkBase first)
    {
        _firstFlag = first;
    }

    public static ILocalFileRenderableBuilder Builder() => new LocalFileRenderableBuilder();

    public override void Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "show";

        if (request.Body.Count >= 2 &&
            request.Body[0].Equals(firstArgument, StringComparison.Ordinal)
            && request.Body[1].Equals(secondArgument, StringComparison.Ordinal))
            _firstFlag.Handle(request);

        Next?.Handle(request);
    }

    private class LocalFileRenderableBuilder : ILocalFileRenderableBuilder
    {
        private FlagLocalFileRenderableSubChainLinkBase? _first;

        public ILocalFileRenderableBuilder AddFirstFlag(FlagLocalFileRenderableSubChainLinkBase flag)
        {
            _first = flag;
            return this;
        }

        public LocalFileRenderable Crate() =>
            new(_first ?? throw new BuilderNullException(nameof(LocalFileRenderableBuilder)));
    }
}