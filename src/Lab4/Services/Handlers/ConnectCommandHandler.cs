using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class ConnectCommandHandler : ICommandHandler
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

        if (command[0] == "connect")
        {
            if (command.Count != 4)
            {
                throw new UnexpectedCommandException();
            }

            if (!Path.IsPathRooted(command[1]))
            {
                throw new NotRootedPathException(command[1]);
            }

            if (!new CorrectFileSystemModes().IsCorrect(new FileSystemMode(command[3])))
            {
                throw new NotSupportedModeException(command[3]);
            }

            var modifiedList = command.Skip(1).ToList();
            var receiver = new ConnectReceiver();

            var temp = new Command(command[0], modifiedList, receiver, workingDirectory);
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