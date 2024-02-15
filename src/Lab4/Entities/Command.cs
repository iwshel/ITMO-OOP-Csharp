using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class Command
{
    private readonly IReceiver _receiver;
    private readonly WorkingDirectory _workingDirectory;

    public Command(string name, IList<string> arguments, IReceiver receiver, WorkingDirectory workingDirectory)
    {
        Name = name;
        Arguments = arguments;
        _receiver = receiver;
        _workingDirectory = workingDirectory;
    }

    public string Name { get; }
    private IList<string> Arguments { get; }

    public void Execute()
    {
        _receiver.Action(Arguments, _workingDirectory);
    }
}