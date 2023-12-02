using System.Globalization;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

public class LocalAddressParser : IAddressParser
{
    public string GetAbsolutePath(string path)
    {
        if (!Path.IsPathRooted(path))
            path = Path.Combine(Directory.GetCurrentDirectory(), path);

        if (Path.IsPathRooted(path) && Path.GetPathRoot(path) != Directory.GetCurrentDirectory())
            return path;

        return Path.GetFullPath(path);
    }

    public string? GetDirectory(string path) => Path.IsPathRooted(path) ? Path.GetPathRoot(path) : null;

    public string CombinePath(string directory, string path) => Path.Combine(directory, Path.GetFileName(path));

    public string GetUniqueName(string directory, string fileName)
    {
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        string fileExtension = Path.GetExtension(fileName);
        var stringBuilder = new StringBuilder();

        string newFileName = fileName;
        int nameCounter = 1;

        while (File.Exists(Path.Combine(directory, newFileName)))
        {
            stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}_{1}{2}", fileNameWithoutExtension, nameCounter, fileExtension);

            newFileName = stringBuilder.ToString();

            nameCounter++;
        }

        return newFileName;
    }
}