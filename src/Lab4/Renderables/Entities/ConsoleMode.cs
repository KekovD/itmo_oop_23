using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Renderables.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;

public class ConsoleMode : ModeFlagSubChainLinkBase
{
    private readonly IContext _context;

    private ConsoleMode(IContext context)
    {
        _context = context;
    }

    public static IConsoleModeBuilder Builder() => new ConsoleModeBuilder();

    public override void Handle(Command request)
    {
        const string targetParameter = "console";
        const string targetValue = "-m";
        const int targetCount = 3;
        const int pathIndex = 2;

        if (request.Flags.Any(flag =>
                flag.Value.Equals(targetValue, StringComparison.Ordinal) &&
                flag.Parameter.Equals(targetParameter, StringComparison.Ordinal)))
            if (request.Body.Count == targetCount) FileConsoleRender(request.Body[pathIndex]);

        Next?.Handle(request);
    }

    private void FileConsoleRender(string filePath)
    {
        string absolutePath = Path.GetFullPath(filePath);

        if (!File.Exists(absolutePath))
        {
            string newPath = Path.Combine(
                _context.Drive ?? throw new ContextNullException(nameof(FileConsoleRender)),
                Path.GetFileName(filePath));

            if (File.Exists(newPath))
            {
                absolutePath = newPath;
            }
            else
            {
                Console.WriteLine("File not found.");
                return;
            }
        }

        string content = File.ReadAllText(absolutePath);
        Console.WriteLine(content);
    }

    private class ConsoleModeBuilder : IConsoleModeBuilder
    {
        private IContext? _context;

        public IConsoleModeBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ConsoleMode Crate() => new(_context ?? throw new BuilderNullException(nameof(ConsoleModeBuilder)));
    }
}