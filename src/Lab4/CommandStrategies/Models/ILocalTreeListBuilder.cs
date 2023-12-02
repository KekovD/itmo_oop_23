using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;

public interface ILocalTreeListBuilder
{
    ILocalTreeListBuilder WithAddressParser(IAddressParser addressParser);
    ILocalTreeListBuilder WithOutput(IOutputStrategy output);
    ILocalTreeListBuilder WithFolderSymbol(string symbol);
    ILocalTreeListBuilder WithFileSymbol(string symbol);
    ILocalTreeListBuilder WithIndentationSymbol(string symbol);
    LocalTreeList Create();
}