using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.ShowFactorys;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

public class FileShowReceiver : IReceiver
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

        if (args.Count > 3)
        {
            throw new UnexpectedCommandException();
        }

        if (workingDirectory.Directory.Exist(newPath))
        {
            if (args.Count == 3)
            {
                if (args[1] != "-m")
                {
                    throw new UnknownFlagException();
                }

                IShow show = new ShowFactory().CreateShow(args[2]);
                if (workingDirectory.File is not null)
                {
                    if (Path.GetExtension(newPath) == ".txt")
                    {
                        show.Show(workingDirectory.File.Read());
                    }
                    else
                    {
                        show.ShowBinary(workingDirectory.File.ReadBinary());
                    }
                }
            }
        }
        else
        {
            throw new DirectoryNotFoundException();
        }
    }
}