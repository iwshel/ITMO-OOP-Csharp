using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

public class FileMoveReceiver : IReceiver
{
    public void Action(IList<string> args, WorkingDirectory workingDirectory)
    {
        args = args ?? throw new ArgumentNullException(nameof(args));
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));
        if (workingDirectory.Directory is null)
        {
            throw new DirectoryNotConnectedException();
        }

        string oldPath = Path.Combine(workingDirectory.GetPath(), args[0]);
        string newPath = Path.Combine(workingDirectory.GetPath(), args[1]);

        if (workingDirectory.Directory.Exist(newPath) && workingDirectory.Directory.Exist(oldPath))
        {
            workingDirectory.SetNewFilePath(oldPath);
            if (workingDirectory.File?.Move(newPath) == new CreateResult.CreateFail())
            {
                throw new FileAlreadyExistsException();
            }
        }
        else
        {
            throw new DirectoryNotFoundException();
        }
    }
}