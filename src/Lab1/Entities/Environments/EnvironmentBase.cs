using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class EnvironmentBase
{
    protected EnvironmentBase(
        SmallAsteroid? smallAsteroid,
        Meteor? meteor,
        CosmoWhale? cosmoWhale,
        AntimatterFlares? antimatterFlares,
        double length)
    {
        SmallAsteroidObstacle = smallAsteroid;
        MeteorObstacle = meteor;
        CosmoWhaleObstacle = cosmoWhale;
        AntimatterFlaresObstacle = antimatterFlares;

        if (length <= 0)
        {
            throw new ArgumentException("length of route must be positive", nameof(length));
        }

        Length = length;
    }

    public SmallAsteroid? SmallAsteroidObstacle { get; }
    public Meteor? MeteorObstacle { get; }
    public CosmoWhale? CosmoWhaleObstacle { get; }
    public AntimatterFlares? AntimatterFlaresObstacle { get; }
    public double Length { get; }
    public abstract bool CheckEngine(ShipBase ship);
    public abstract void TakeShip(ShipBase shipBase, EnvironmentBase environmentBase, ResultOfRoute resultOfRoute);
}