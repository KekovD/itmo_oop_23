﻿using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalCopyFile : CommandBase
{
    private IContext? _context;

    public LocalCopyFile()
    {
        Characteristics = new CommandFeatures("file copy", "local", string.Empty);
    }

    public override void Execute(Command request, IContext context)
    {
        _context = context;

        int sourceIndex = request.PathIndex;

        int destinationIndex = sourceIndex + NextIndex;

        CopyFile(request.Body[sourceIndex], request.Body[destinationIndex]);
    }

    private void CopyFile(string sourcePath, string destinationPath)
    {
        if (_context is null) return;

        string connectionMode = _context.GetConnectedMode();
        string sourceFullPath = _context.GetAbsoluteAddress(sourcePath, connectionMode);
        string destinationDir = _context.GetAbsoluteAddress(destinationPath, connectionMode);

        if (!File.Exists(sourceFullPath)) return;

        string fileName = Path.GetFileName(sourceFullPath);
        string destinationFullPath = Path.Combine(destinationDir, fileName);

        if (File.Exists(destinationFullPath))
        {
            destinationFullPath = Path.Combine(
                destinationDir,
                _context.GetUniqueFileName(destinationDir, fileName, connectionMode));
        }

        File.Copy(sourceFullPath, destinationFullPath);
    }
}