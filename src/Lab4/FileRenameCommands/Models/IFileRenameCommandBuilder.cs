using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Models;

public interface IFileRenameCommandBuilder
{
    IFileRenameCommandBuilder WithFlagsSubChain(FlagsFileRenameSubChainLinqBase flagsChain);
    FileRenameCommandLinq Create();
}