using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class DisconnectCommandHandler : ICommandHandler
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

        if (command[0] == "disconnect")
        {
            var temp = new Command(command[0], new Collection<string>(), new DisconnectReceiver(), workingDirectory);
            temp.Execute();
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