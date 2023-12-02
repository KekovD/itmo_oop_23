using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class LocalTreeList : IStrategy
{
    private readonly IAddressParser _addressParser;
    private readonly IOutputStrategy _output;
    private readonly string _folderSymbol = "-";
    private readonly string _fileSymbol = "#";
    private readonly string _indentationSymbol = " ";

    private LocalTreeList(
        IAddressParser addressParser,
        IOutputStrategy output,
        string? folderSymbol,
        string? fileSymbol,
        string? indentationSymbol)
    {
        _addressParser = addressParser;
        _output = output;
        _folderSymbol = folderSymbol ?? _folderSymbol;
        _fileSymbol = fileSymbol ?? _fileSymbol;
        _indentationSymbol = indentationSymbol ?? _indentationSymbol;
    }

    public static ILocalTreeListBuilder Builder() => new LocalTreeListBuilder();

    public void Execute(IContext context, IList<string> request)
    {
        const int depthIndex = 0;

        PrintDirectoryTree(
            _addressParser.GetAbsolutePath(
                context.Address
                ?? throw new ContextNullException($"{nameof(PrintDirectoryTree)} in {nameof(LocalTreeList)} {nameof(_addressParser)} is null")),
            int.Parse(request[depthIndex], NumberStyles.Integer, CultureInfo.InvariantCulture),
            _folderSymbol,
            _fileSymbol,
            _indentationSymbol,
            new StringBuilder());
    }

    private void PrintDirectoryTree(string rootPath, int depth, string folderSymbol, string fileSymbol, string indentationSymbol, StringBuilder stringBuilder)
    {
        try
        {
            var rootDir = new DirectoryInfo(rootPath);

            if (depth <= 0 || !rootDir.Exists) return;

            const string tabSpace = "   ";
            const int decrementedDepth = 1;

            foreach (DirectoryInfo directory in rootDir.GetDirectories())
            {
                try
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}{1} {2}", indentationSymbol, folderSymbol, directory.Name);
                    _output.Write(stringBuilder.ToString());

                    stringBuilder.Clear();
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}{1}{2}", indentationSymbol, tabSpace, folderSymbol);

                    PrintDirectoryTree(
                        directory.FullName,
                        depth - decrementedDepth,
                        folderSymbol,
                        fileSymbol,
                        stringBuilder.ToString(),
                        stringBuilder);
                }
                catch (UnauthorizedAccessException)
                {
                    _output.Write($"Access denied to directory: {directory.FullName}");
                }
            }

            foreach (FileInfo file in rootDir.GetFiles())
            {
                try
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}{1} {2}", indentationSymbol, fileSymbol, file.Name);
                    _output.Write(stringBuilder.ToString());
                }
                catch (UnauthorizedAccessException)
                {
                    _output.Write($"Access denied to file: {file.FullName}");
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            _output.Write($"Access denied to {rootPath}");
        }
    }

    private class LocalTreeListBuilder : ILocalTreeListBuilder
    {
        private IAddressParser? _addressParser;
        private IOutputStrategy? _output;
        private string? _folderSymbol;
        private string? _fileSymbol;
        private string? _indentationSymbol;

        public ILocalTreeListBuilder WithAddressParser(IAddressParser addressParser)
        {
            _addressParser = addressParser;
            return this;
        }

        public ILocalTreeListBuilder WithOutput(IOutputStrategy output)
        {
            _output = output;
            return this;
        }

        public ILocalTreeListBuilder WithFolderSymbol(string symbol)
        {
            _folderSymbol = symbol;
            return this;
        }

        public ILocalTreeListBuilder WithFileSymbol(string symbol)
        {
            _fileSymbol = symbol;
            return this;
        }

        public ILocalTreeListBuilder WithIndentationSymbol(string symbol)
        {
            _indentationSymbol = symbol;
            return this;
        }

        public LocalTreeList Create() => new(
            _addressParser ?? throw new BuilderNullException($"{nameof(LocalTreeListBuilder)} {nameof(_addressParser)} is null"),
            _output ?? throw new BuilderNullException($"{nameof(LocalTreeListBuilder)} {nameof(_output)} is null"),
            _folderSymbol,
            _fileSymbol,
            _indentationSymbol);
    }
}