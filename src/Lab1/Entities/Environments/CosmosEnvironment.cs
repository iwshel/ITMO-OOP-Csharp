using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exeptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class CosmosEnvironment : EnvironmentBase
{
    public CosmosEnvironment(SmallAsteroid? smallAsteroid, Meteor? meteor, double length)
        : base(
            smallAsteroid,
            meteor,
            null,
            null,
            length)
    {
        if (length <= 0)
        {
            throw new ZeroLengthOfEnvironmentException("length of route must be positive");
        }
    }

    public CosmosEnvironment()
        : base(
            null,
            null,
            null,
            null,
            1)
    {
    }

    public override bool CheckEngine(ShipBase ship)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (!ship.IsEnvironmentSupported(new CosmosEnvironment()))
        {
            return false;
        }

        return true;
    }

    public override void TakeShip(ShipBase shipBase, EnvironmentBase environmentBase, ResultOfRoute resultOfRoute)
    {
        if (shipBase is null)
        {
            throw new ArgumentNullException(nameof(shipBase));
        }

        if (environmentBase is null)
        {
            throw new ArgumentNullException(nameof(environmentBase));
        }

        if (resultOfRoute is null)
        {
            throw new ArgumentNullException(nameof(resultOfRoute));
        }

        shipBase.GoToEnvironment(environmentBase, resultOfRoute);
        shipBase.TakeDamage(environmentBase.MeteorObstacle);
        shipBase.TakeDamage(environmentBase.SmallAsteroidObstacle);
    }
}