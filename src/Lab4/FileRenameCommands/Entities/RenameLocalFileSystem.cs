using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;

public class RenameLocalFileSystem : RenameFileSystemSubChainLinqBase
{
    private readonly IContext _context;
    private readonly ICommand _command;

    private RenameLocalFileSystem(IContext context)
    {
        _context = context;
        _command = new LocalRenameFile(context);
    }

    public static IRenameLocalFileSystemBuilder Builder() => new RenameLocalFileSystemBuilder();

    public override void Handle(Command request)
    {
        const string targetMode = "local";
        const int targetCount = 4;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (_context.CheckConnectedMode(targetMode) &&
            request.Body.Count == targetCount)
            _command.Execute(request);

        Next?.Handle(request);
    }

    private class RenameLocalFileSystemBuilder : IRenameLocalFileSystemBuilder
    {
        private IContext? _context;

        public IRenameLocalFileSystemBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public RenameLocalFileSystem Create() =>
            new(_context ?? throw new BuilderNullException(nameof(RenameLocalFileSystemBuilder)));
    }
}