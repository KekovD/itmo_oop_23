using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

public class LocalAddressParser : IAddressParser
{
    public string GetAddress(Command request)
    {
        const int targetCount = 2;

        return request.Body.Count >= targetCount &&
               !string.IsNullOrEmpty(request.Body[request.PathIndex]) ? GetAbsolutePath(request.Body[request.PathIndex]) : string.Empty;
    }

    public string GetDrive(Command request)
    {
        const int targetCount = 2;
        const int targetLength = 3;

        string drive = string.Empty;

        if (request.Body.Count >= targetCount && !string.IsNullOrEmpty(request.Body[request.PathIndex]))
            drive = Path.GetPathRoot(request.Body[request.PathIndex]) ?? string.Empty;

        return !string.IsNullOrEmpty(drive) &&
               drive.Length == targetLength ? drive : string.Empty;
    }

    public string GetAbsolutePath(string path)
    {
        if (!Path.IsPathRooted(path))
            path = Path.Combine(Directory.GetCurrentDirectory(), path);

        if (Path.IsPathRooted(path) && Path.GetPathRoot(path) != Directory.GetCurrentDirectory())
            return path;

        return Path.GetFullPath(path);
    }

    public string GetUniqueName(string directory, string fileName)
    {
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        string fileExtension = Path.GetExtension(fileName);
        int nameCounter = 1;

        string newFileName = fileName;
        while (File.Exists(Path.Combine(directory, newFileName)))
        {
            newFileName = string.Format(
                System.Globalization.CultureInfo.InvariantCulture, "{0}_{1}{2}", fileNameWithoutExtension, nameCounter, fileExtension);
            nameCounter++;
        }

        return newFileName;
    }
}