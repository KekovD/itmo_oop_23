using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;

public class DeleteLocalFileSystem : DeleteFileSystemSubChainLinqBase
{
    private readonly IContext _context;
    private readonly ICommand _command;

    private DeleteLocalFileSystem(IContext context)
    {
        _context = context;
        _command = new LocalDeleteFile(context);
    }

    public static IDeleteLocalFileSystemBuilder Builder() => new DeleteLocalFileSystemBuilder();

    public override void Handle(Command request)
    {
        const string targetMode = "local";
        const int targetCount = 3;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (_context.CheckConnectedMode(targetMode) &&
            request.Body.Count == targetCount)
            _command.Execute(request);

        Next?.Handle(request);
    }

    private class DeleteLocalFileSystemBuilder : IDeleteLocalFileSystemBuilder
    {
        private IContext? _context;

        public IDeleteLocalFileSystemBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public DeleteLocalFileSystem Create() =>
            new(_context ?? throw new BuilderNullException(nameof(DeleteLocalFileSystemBuilder)));
    }
}