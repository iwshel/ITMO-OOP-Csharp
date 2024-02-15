using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public interface ICommandHandler
{
    void Handle(IList<string> command, WorkingDirectory workingDirectory);
}