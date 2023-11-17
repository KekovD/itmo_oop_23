using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Models;

public interface ICopyLocalFileSystemBuilder
{
    ICopyLocalFileSystemBuilder WithContext(IContext context);
    CopyLocalFileSystem Create();
}