using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;

public class ConsoleMode : ModeFlagSubChainLinkBase
{
    public override void Handle(Command request)
    {
        const string targetParameter = "console";
        const string targetValue = "-m";

        if (request.Flags.Any(flag =>
                flag.Value.Equals(targetValue, StringComparison.Ordinal) &&
                flag.Parameter.Equals(targetParameter, StringComparison.Ordinal)))
            if (request.Body.Count == 3) FileConsoleRender(request.Body[2]);

        Next?.Handle(request);
    }

    private static void FileConsoleRender(string filePath)
    {
        string absolutePath = Path.GetFullPath(filePath);

        if (!File.Exists(absolutePath)) Console.WriteLine("File not found.");

        string content = File.ReadAllText(absolutePath);
        Console.WriteLine(content);
    }
}