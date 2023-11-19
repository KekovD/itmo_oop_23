using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public interface ILocalConsoleTreeListCommandBuilder
{
    ILocalConsoleTreeListCommandBuilder WithFolderSymbol(string symbol);
    ILocalConsoleTreeListCommandBuilder WithFileSymbol(string symbol);
    ILocalConsoleTreeListCommandBuilder WithIndentationSymbol(string symbol);

    LocalConsoleTreeListCommand Create();
}