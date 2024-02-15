using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class NullRegularEngine : RegularEngineBase
{
    public NullRegularEngine()
        : base(0, 0)
    {
    }

    public override void GoIntoEnvironment(EnvironmentBase environmentBase, ResultOfRoute resultOfRoute)
    {
    }
}