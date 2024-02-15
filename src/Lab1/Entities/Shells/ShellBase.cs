using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class ShellBase
{
    protected ShellBase(double maxHitPoints)
    {
        if (maxHitPoints <= 0)
        {
            throw new ArgumentException("max hit points must be positive", nameof(maxHitPoints));
        }

        MaxHitPoints = maxHitPoints;
        CurrentHitPoints = maxHitPoints;
    }

    public double MaxHitPoints { get; }

    public bool IsShellDead => CurrentHitPoints < 0;

    public double CurrentHitPoints { get; private set; }

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        double actual = obstacle.Damage;

        CurrentHitPoints -= actual;
    }
}