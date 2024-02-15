using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class ObstacleBase
{
    protected ObstacleBase(double obstacleDefaultDamage, bool photonicDamage)
    {
        if (obstacleDefaultDamage < 0)
        {
            throw new ArgumentException("obstacle damage must be positive", nameof(obstacleDefaultDamage));
        }

        Damage = obstacleDefaultDamage;
        PhotonicDamage = photonicDamage;
    }

    public double Damage { get; private set; }

    public bool IsAlive => Damage >= 0;

    public bool PhotonicDamage { get; private set; }

    public void TakeDamage(double damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("damage must be positive", nameof(damage));
        }

        Damage -= damage;
    }
}