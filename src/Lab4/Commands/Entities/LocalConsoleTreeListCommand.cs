using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalConsoleTreeListCommand : CommandBase
{
    private readonly string _folderSymbol = "#";
    private readonly string _fileSymbol = "-";
    private readonly string _indentationSymbol = " ";

    private LocalConsoleTreeListCommand(string? folderSymbol, string? fileSymbol, string? indentationSymbol)
    {
        _folderSymbol = folderSymbol ?? _folderSymbol;
        _fileSymbol = fileSymbol ?? _fileSymbol;
        _indentationSymbol = indentationSymbol ?? _indentationSymbol;

        Characteristics = new CommandFeatures("tree list", "local", "console");
    }

    public static ILocalConsoleTreeListCommandBuilder Builder() => new LocalConsoleTreeListCommandBuilder();

    public override void Execute(Command request, IContext context)
    {
        PrintDirectoryTree(
            context.GetAbsoluteAddress(context.Address ?? throw new ContextNullException(nameof(context.Address))),
            request.PathIndex,
            _folderSymbol,
            _fileSymbol,
            _indentationSymbol);
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

    private class LocalConsoleTreeListCommandBuilder : ILocalConsoleTreeListCommandBuilder
    {
        private string? _folderSymbol;
        private string? _fileSymbol;
        private string? _indentationSymbol;

        public ILocalConsoleTreeListCommandBuilder WithFolderSymbol(string symbol)
        {
            _folderSymbol = symbol;
            return this;
        }

        public ILocalConsoleTreeListCommandBuilder WithFileSymbol(string symbol)
        {
            _fileSymbol = symbol;
            return this;
        }

        public ILocalConsoleTreeListCommandBuilder WithIndentationSymbol(string symbol)
        {
            _indentationSymbol = symbol;
            return this;
        }

        public LocalConsoleTreeListCommand Create() => new(_folderSymbol, _fileSymbol, _indentationSymbol);
    }
}