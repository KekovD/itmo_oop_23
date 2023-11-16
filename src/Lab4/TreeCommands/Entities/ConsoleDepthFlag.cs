using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class ConsoleDepthFlag : DepthFlagSubChainLinqBase
{
    private readonly IContext _context;
    private readonly string _folderSymbol = "#";
    private readonly string _fileSymbol = "-";
    private readonly string _indentationSymbol = " ";

    private ConsoleDepthFlag(IContext context, string? folderSymbol, string? fileSymbol, string? indentationSymbol)
    {
        _context = context;
        _folderSymbol = folderSymbol ?? _folderSymbol;
        _fileSymbol = fileSymbol ?? _fileSymbol;
        _indentationSymbol = indentationSymbol ?? _indentationSymbol;
    }

    public static IConsoleDepthFlagBuilder Builder() => new ConsoleDepthFlagBuilder();

    public override void Handle(Command request)
    {
        const int targetCount = 3;
        const int pathIndex = 2;
        const string modeParameter = "console";
        const string connectedModeParameter = "local";
        const string modeValue = "-m";
        const string depthValue = "-d";

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count == targetCount &&
            request.Flags.Any(flag =>
                flag.Value.Equals(modeValue, StringComparison.Ordinal) &&
                flag.Parameter.Equals(modeParameter, StringComparison.Ordinal)) &&
            _context.CheckConnectedMode(connectedModeParameter))
        {
            const int standardDepth = 1;
            int depth = standardDepth;
            depth = request.Flags.Any(flag => flag.Value.Equals(depthValue, StringComparison.Ordinal) &&
                                              int.TryParse(
                                                  flag.Parameter,
                                                  NumberStyles.Integer,
                                                  CultureInfo.InvariantCulture,
                                                  out depth)) ? depth : standardDepth;

            PrintDirectoryTree(
                _context.GetAbsoluteAddress(request.Body[pathIndex]),
                depth,
                _folderSymbol,
                _fileSymbol,
                _indentationSymbol);
        }

        Next?.Handle(request);
    }

    private void PrintDirectoryTree(string rootPath, int depth, string folderSymbol, string fileSymbol, string indentationSymbol)
    {
        var rootDir = new DirectoryInfo(rootPath);

        Console.WriteLine(string.Concat(indentationSymbol, rootDir.FullName));

        if (depth <= 0 || !rootDir.Exists) return;

        const string singleSpace = " ";
        const string tabSpace = "   ";
        const int decrementedDepth = 1;

        foreach (DirectoryInfo directory in rootDir.GetDirectories())
        {
            Console.WriteLine(string.Concat(indentationSymbol, folderSymbol, singleSpace, directory.Name));
            PrintDirectoryTree(
                directory.FullName,
                depth - decrementedDepth,
                folderSymbol,
                fileSymbol,
                string.Concat(indentationSymbol, tabSpace, folderSymbol));
        }

        foreach (FileInfo file in rootDir.GetFiles())
        {
            Console.WriteLine(string.Concat(indentationSymbol, fileSymbol, singleSpace, file.Name));
        }
    }

    private class ConsoleDepthFlagBuilder : IConsoleDepthFlagBuilder
    {
        private IContext? _context;
        private string? _folderSymbol;
        private string? _fileSymbol;
        private string? _indentationSymbol;

        public IConsoleDepthFlagBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IConsoleDepthFlagBuilder WithFolderSymbol(string symbol)
        {
            _folderSymbol = symbol;
            return this;
        }

        public IConsoleDepthFlagBuilder WithFileSymbol(string symbol)
        {
            _fileSymbol = symbol;
            return this;
        }

        public IConsoleDepthFlagBuilder WithIndentation(string symbol)
        {
            _indentationSymbol = symbol;
            return this;
        }

        public ConsoleDepthFlag Crate() => new(
            _context ?? throw new BuilderNullException(nameof(ConsoleDepthFlagBuilder)),
            _folderSymbol,
            _fileSymbol,
            _indentationSymbol);
    }
}