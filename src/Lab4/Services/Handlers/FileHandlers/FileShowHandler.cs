using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.FileHandlers;

public class FileShowHandler : ICommandHandler
{
    private ICommandHandler? NextFileHandler { get; set; }

    public ICommandHandler SetNextFileHandler(ICommandHandler handler)
    {
        NextFileHandler = handler;
        return handler;
    }

    public void Handle(IList<string> command, WorkingDirectory workingDirectory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));

        if (command[1] == "show")
        {
            if (command.Count < 3)
            {
                throw new NotEnoughArgumentsException(nameof(command));
            }

            var modifiedList = command.Skip(2).ToList();

            var temp = new Command(command[0] + ' ' + command[1], modifiedList, new FileShowReceiver(), workingDirectory);
            temp.Execute();
        }
        else
        {
            if (NextFileHandler is not null)
            {
                NextFileHandler.Handle(command, workingDirectory);
            }
            else
            {
                throw new UnexpectedCommandException();
            }
        }
    }
}