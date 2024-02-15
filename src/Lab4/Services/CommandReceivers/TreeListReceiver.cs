using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TreePrinters;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TreeVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

public class TreeListReceiver : IReceiver
{
    public void Action(IList<string> args, WorkingDirectory workingDirectory)
    {
        args = args ?? throw new ArgumentNullException(nameof(args));
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));
        if (workingDirectory.Directory is null)
        {
            throw new DirectoryNotConnectedException();
        }

        int maxDeph = 1;

        if (args.Count == 2)
        {
            if (args[0] != "-d")
            {
                throw new UnknownFlagException();
            }

            if (!int.TryParse(args[1], out maxDeph))
            {
                throw new NotIntDephException();
            }
        }
        else if (args.Count > 2)
        {
            throw new UnexpectedCommandException();
        }

        var visitor = new TreeVisitor();
        var printer = new TreePrinter(visitor, workingDirectory.Directory);
        Console.WriteLine(printer.PrintTree(
            maxDeph,
            new IndentSelecter().GetEmoji("folder"),
            new IndentSelecter().GetEmoji("file")));
    }
}