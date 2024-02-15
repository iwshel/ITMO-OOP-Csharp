using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.TreeHandlers;

public class TreeGotoHandler : ICommandHandler
{
    private ICommandHandler? NextTreeHandler { get; set; }

    public ICommandHandler SetNextTreeHandler(ICommandHandler handler)
    {
        NextTreeHandler = handler;
        return handler;
    }

    public void Handle(IList<string> command, WorkingDirectory workingDirectory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));

        if (command[1] == "goto")
        {
            if (command.Count != 3)
            {
                throw new UnexpectedCommandException(nameof(command));
            }

            var modifiedList = command.Skip(2).ToList();

            var temp = new Command(command[0] + ' ' + command[1], modifiedList, new TreeGotoReceiver(), workingDirectory);
            temp.Execute();
        }
        else
        {
            if (NextTreeHandler is not null)
            {
                NextTreeHandler.Handle(command, workingDirectory);
            }
            else
            {
                throw new UnexpectedCommandException();
            }
        }
    }
}