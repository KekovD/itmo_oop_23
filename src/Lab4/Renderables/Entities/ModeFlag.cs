﻿using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Renderables.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;

public class ModeFlag : FlagFileShowSubChainLinkBase
{
    private ModeFlag(ModeFlagSubChainLinkBase mode)
    {
        Mode = mode;
    }

    public ModeFlagSubChainLinkBase Mode { get; }

    public static IModeFlagBuilder Build() => new ModeFlagBuilder();

    public override void Handle(Command request)
    {
        const string targetValue = "-m";

        if (request.Flags.Any(flag => flag.Value.Equals(targetValue, StringComparison.Ordinal)))
            Mode.Handle(request);

        Next?.Handle(request);
    }

    private class ModeFlagBuilder : IModeFlagBuilder
    {
        private ModeFlagSubChainLinkBase? _mode;

        public IModeFlagBuilder AddFirstMode(ModeFlagSubChainLinkBase mode)
        {
            _mode = mode;
            return this;
        }

        public ModeFlag Crate() => new(_mode ?? throw new BuilderNullException(nameof(ModeFlagBuilder)));
    }
}