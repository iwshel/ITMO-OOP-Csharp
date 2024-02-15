using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.TreeHandlers;

public class TreeHandler : ICommandHandler
{
    private ICommandHandler? NextHandler { get; set; }
    private ICommandHandler? NextTreeHandler { get; set; }

    public void SetNextHandler(ICommandHandler handler)
    {
        NextHandler = handler;
    }

    public void SetNextTreeHandler(ICommandHandler handler)
    {
        NextTreeHandler = handler;
    }

    public void Handle(IList<string> command, WorkingDirectory workingDirectory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));

        if (command[0] == "tree")
        {
            if (command.Count < 2)
            {
                throw new NotEnoughArgumentsException();
            }

            NextTreeHandler?.Handle(command, workingDirectory);
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