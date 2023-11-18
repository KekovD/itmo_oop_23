using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;

public class CopyLocalFileSystem : CopyFileSystemSubChainLinqBase
{
    private readonly IContext _context;
    private readonly ICommand _command;

    private CopyLocalFileSystem(IContext context)
    {
        _context = context;
        _command = new LocalCopyFile(context);
    }

    public static ICopyLocalFileSystemBuilder Builder() => new CopyLocalFileSystemBuilder();

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

    private class CopyLocalFileSystemBuilder : ICopyLocalFileSystemBuilder
    {
        private IContext? _context;

        public ICopyLocalFileSystemBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public CopyLocalFileSystem Create() =>
            new(_context ?? throw new BuilderNullException(nameof(CopyLocalFileSystemBuilder)));
    }
}