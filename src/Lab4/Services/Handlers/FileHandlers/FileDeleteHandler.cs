using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.FileHandlers;

public class FileDeleteHandler : ICommandHandler
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

        if (command[1] == "delete")
        {
            if (command.Count != 3)
            {
                throw new UnexpectedCommandException(nameof(command));
            }

            var modifiedList = command.Skip(2).ToList();

            var temp = new Command(command[0] + ' ' + command[1], modifiedList, new FileDeleteReceiver(), workingDirectory);
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