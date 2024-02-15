using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandReceivers;

public interface IReceiver
{
    void Action(IList<string> args, WorkingDirectory workingDirectory);
}