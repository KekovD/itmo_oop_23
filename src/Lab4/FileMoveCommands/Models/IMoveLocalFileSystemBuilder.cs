using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Models;

public interface IMoveLocalFileSystemBuilder
{
    IMoveLocalFileSystemBuilder WithContext(IContext context);
    MoveLocalFileSystem Crate();
}