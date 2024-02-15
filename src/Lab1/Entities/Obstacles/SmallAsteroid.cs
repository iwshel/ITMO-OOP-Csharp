using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class SmallAsteroid : ObstacleBase
{
    public SmallAsteroid()
        : base(AllConstants.SmallAsteroidDamage, false)
    {
    }
}