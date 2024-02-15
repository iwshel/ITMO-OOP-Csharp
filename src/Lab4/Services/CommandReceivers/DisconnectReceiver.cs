using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

public class DisconnectReceiver : IReceiver
{
    public void Action(IList<string> args, WorkingDirectory workingDirectory)
    {
        args = args ?? throw new ArgumentNullException(nameof(args));
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));
        workingDirectory.SetNewDirectory(null);
        if (args.Count > 0)
        {
            throw new UnexpectedCommandException();
        }
    }
}