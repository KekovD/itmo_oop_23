using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Services;

public class LocalAddressParser : IAddressParser
{
    public string GetAddress(Command request)
    {
        const int targetIndex = 1;
        const int targetCount = 2;
        const string value = "-m";
        const string mode = "local";

        if (!request.Flags.Any(flag => flag.Value.Equals(value, StringComparison.Ordinal) &&
                                       flag.Parameter.Equals(mode, StringComparison.Ordinal)))
            return string.Empty;

        return request.Body.Count >= targetCount &&
               !string.IsNullOrEmpty(request.Body[targetIndex]) ? request.Body[targetIndex] : string.Empty;
    }

    public string GetDrive(Command request)
    {
        const int targetIndex = 1;
        const int targetCount = 2;
        const int targetLength = 2;
        const char targetChar = ':';

        string drive = string.Empty;

        if (request.Body.Count >= targetCount && !string.IsNullOrEmpty(request.Body[targetIndex]))
            drive = Path.GetPathRoot(request.Body[targetIndex]) ?? string.Empty;

        return !string.IsNullOrEmpty(drive) &&
               drive.Length == targetLength &&
               drive[targetIndex] == targetChar ? drive : string.Empty;
    }

    public string GetAbsolutePath(string path)
    {
        if (!Path.IsPathRooted(path))
            path = Path.Combine(Directory.GetCurrentDirectory(), path);

        if (Path.IsPathRooted(path) && Path.GetPathRoot(path) != Directory.GetCurrentDirectory())
            return path;

        return Path.GetFullPath(path);
    }
}