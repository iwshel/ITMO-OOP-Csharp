using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exeptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class NebulaeOfIncreasedDensityOfSpaceEnvironment : EnvironmentBase
{
    public NebulaeOfIncreasedDensityOfSpaceEnvironment(
        AntimatterFlares? antimatterFlares,
        double length)
        : base(
            null,
            null,
            null,
            antimatterFlares,
            length)
    {
        if (length <= 0)
        {
            throw new ZeroLengthOfEnvironmentException("length of route must be positive");
        }
    }

    public NebulaeOfIncreasedDensityOfSpaceEnvironment()
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

        if (!ship.IsEnvironmentSupported(new NebulaeOfIncreasedDensityOfSpaceEnvironment()))
        {
            return false;
        }

        return ship.IsLengthCorrect(Length);
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
        shipBase.TakeDamage(environmentBase.AntimatterFlaresObstacle);
    }
}