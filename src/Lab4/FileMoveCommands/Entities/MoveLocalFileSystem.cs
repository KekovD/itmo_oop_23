using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;

public class MoveLocalFileSystem : MoveFileSystemSubChainLinqBase
{
    private readonly IContext _context;
    private readonly ICommand _command;

    private MoveLocalFileSystem(IContext context)
    {
        _context = context;
        _command = new LocalMoveFile(context);
    }

    public static IMoveLocalFileSystemBuilder Builder() => new MoveLocalFileSystemBuilder();

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

    private class MoveLocalFileSystemBuilder : IMoveLocalFileSystemBuilder
    {
        private IContext? _context;

        public IMoveLocalFileSystemBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public MoveLocalFileSystem Create() =>
            new(_context ?? throw new BuilderNullException(nameof(MoveLocalFileSystemBuilder)));
    }
}