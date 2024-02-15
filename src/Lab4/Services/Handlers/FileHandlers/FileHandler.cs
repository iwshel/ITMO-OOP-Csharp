using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.FileHandlers;

public class FileHandler : ICommandHandler
{
    private ICommandHandler? NextHandler { get; set; }
    private ICommandHandler? NextFileHandler { get; set; }

    public void SetNextHandler(ICommandHandler handler)
    {
        NextHandler = handler;
    }

    public void SetNextFileHandler(ICommandHandler handler)
    {
        NextFileHandler = handler;
    }

    public void Handle(IList<string> command, WorkingDirectory workingDirectory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));

        if (command[0] == "file")
        {
            if (command.Count < 2)
            {
                throw new NotEnoughArgumentsException(nameof(command));
            }

            NextFileHandler?.Handle(command, workingDirectory);
        }
        else
        {
            if (NextHandler is not null)
            {
                NextHandler.Handle(command, workingDirectory);
            }
            else
            {
                throw new UnexpectedCommandException();
            }
        }
    }
}