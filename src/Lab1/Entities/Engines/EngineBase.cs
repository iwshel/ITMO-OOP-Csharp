namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class EngineBase
{
    public EngineBase(JumpEngineBase? jumpEngine, RegularEngineBase? regularEngine)
    {
        JumpEngine = jumpEngine ?? new NullJumpEngine();
        RegularEngine = regularEngine ?? new NullRegularEngine();
    }

    public JumpEngineBase JumpEngine { get; }

    public RegularEngineBase RegularEngine { get; }
}