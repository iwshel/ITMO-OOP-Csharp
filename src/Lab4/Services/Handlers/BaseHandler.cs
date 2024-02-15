using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class BaseHandler : ICommandHandler
{
    private ICommandHandler? NextHandler { get; set; }

    public ICommandHandler SetNextHandler(ICommandHandler handler)
    {
        NextHandler = handler;
        return handler;
    }

    public void Handle(IList<string> command, WorkingDirectory workingDirectory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));

        if (command.Count == 0)
        {
            throw new EmptyCommandException();
        }

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