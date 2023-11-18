using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalConsoleDepthFlag : ICommand
{
    private readonly IContext _context;
    private readonly string _folderSymbol;
    private readonly string _fileSymbol;
    private readonly string _indentationSymbol;

    public LocalConsoleDepthFlag(IContext context, string folderSymbol, string fileSymbol, string indentationSymbol)
    {
        _context = context;
        _folderSymbol = folderSymbol;
        _fileSymbol = fileSymbol;
        _indentationSymbol = indentationSymbol;
    }

    public void Execute(Command request)
    {
        PrintDirectoryTree(
            _context.GetAbsoluteAddress(_context.Address ?? throw new ContextNullException(nameof(_context.Address))),
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
}