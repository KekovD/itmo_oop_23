using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Models;

public interface IDeleteLocalFileSystemBuilder
{
    IDeleteLocalFileSystemBuilder WithContext(IContext context);
    DeleteLocalFileSystem Create();
}