using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class DeflectorBase
{
    protected DeflectorBase(double maxHitPoints)
    {
        if (maxHitPoints < 0)
        {
            throw new ArgumentException("max hit points must be positive", nameof(maxHitPoints));
        }

        MaxHitPoints = maxHitPoints;
        CurrentHitPoints = maxHitPoints;
        PhotonDeflectorAmount = 0;
    }

    public double MaxHitPoints { get; }

    public bool IsAlive => CurrentHitPoints > 0;

    public int PhotonDeflectorAmount { get; private set; }

    public double CurrentHitPoints { get; private set; }

    public virtual void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        double actual = CurrentHitPoints > obstacle.Damage ? obstacle.Damage : this.CurrentHitPoints;
        CurrentHitPoints -= actual;
        obstacle.TakeDamage(actual);
    }

    public bool TakePhotonicDamage()
    {
        if (PhotonDeflectorAmount <= 0)
        {
            return true;
        }

        PhotonDeflectorAmount--;
        return false;
    }

    public void SetPhotonicDeflector()
    {
        PhotonDeflectorAmount = 3;
    }
}