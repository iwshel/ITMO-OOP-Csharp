namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class NullDeflector : DeflectorBase
{
    public NullDeflector()
        : base(0)
    {
    }

    public override void TakeDamage(ObstacleBase obstacle)
    {
    }
}