using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class LocalFileShow : IStrategy
{
    private readonly IAddressParser _addressParser;
    private readonly IOutputStrategy _output;

    public LocalFileShow(IAddressParser addressParser, IOutputStrategy output)
    {
        _addressParser = addressParser;
        _output = output;
    }

    public void Execute(IContext context, IList<string> request)
    {
        const int pathIndex = 0;
        string filePath = request[pathIndex];
        string absolutePath = _addressParser.GetAbsolutePath(filePath);

        if (!File.Exists(absolutePath))
        {
            if (context.Drive is null)
            {
                _output.Write("Drive is null.");
                return;
            }

            string newPath = _addressParser.CombinePath(context.Drive, filePath);

            if (File.Exists(newPath))
            {
                absolutePath = newPath;
            }
            else
            {
                _output.Write("File not found.");
                return;
            }
        }

        string content = File.ReadAllText(absolutePath);
        _output.Write(content);
    }
}