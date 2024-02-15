using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

public class FileRenameReceiver : IReceiver
{
    public void Action(IList<string> args, WorkingDirectory workingDirectory)
    {
        args = args ?? throw new ArgumentNullException(nameof(args));
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));
        if (workingDirectory.Directory is null)
        {
            throw new DirectoryNotConnectedException();
        }

        string newPath = Path.Combine(workingDirectory.GetPath(), args[0]);

        if (workingDirectory.Directory.Exist(newPath))
        {
            string newName = string.Empty;
            for (int i = 1; i < args.Count; i++)
            {
                newName += args[i] + ' ';
            }

            workingDirectory.SetNewFilePath(newPath);
            workingDirectory.File?.Rename(newName);
        }
        else
        {
            throw new DirectoryNotFoundException();
        }
    }
}