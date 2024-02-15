using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

public class ConnectReceiver : IReceiver
{
    public void Action(IList<string> args, WorkingDirectory workingDirectory)
    {
        args = args ?? throw new ArgumentNullException(nameof(args));
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        workingDirectory.SetNewDirectory(new DirectoryProviderObject(args[0]));

        if (args[1] != "-m")
        {
            throw new UnknownFlagException();
        }

        IFileProvider fileProvider = new FileTypeFactory().CreateFile(args[2]);
        workingDirectory.SetNewFile(fileProvider);
    }
}