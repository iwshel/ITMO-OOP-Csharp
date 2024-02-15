using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class NullJumpEngine : JumpEngineBase
{
    public NullJumpEngine()
        : base(0, 0)
    {
    }

    public override bool CheckLength(double length)
    {
        return false;
    }

    public override void GoIntoEnvironment(EnvironmentBase environmentBase, ResultOfRoute resultOfRoute)
    {
    }
}