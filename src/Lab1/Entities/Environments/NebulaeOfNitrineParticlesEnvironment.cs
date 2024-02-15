using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exeptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class NebulaeOfNitrineParticlesEnvironment : EnvironmentBase
{
    public NebulaeOfNitrineParticlesEnvironment(CosmoWhale? cosmoWhale, double length)
        : base(
            null,
            null,
            cosmoWhale,
            null,
            length)
    {
        if (length <= 0)
        {
            throw new ZeroLengthOfEnvironmentException("length of route must be positive");
        }
    }

    public NebulaeOfNitrineParticlesEnvironment()
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

        if (!ship.IsEnvironmentSupported(new NebulaeOfNitrineParticlesEnvironment()))
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
        if (!shipBase.AntiNitrineEmitter && environmentBase.CosmoWhaleObstacle is not null)
        {
            for (int k = 0; k < environmentBase.CosmoWhaleObstacle.Population; k++)
            {
                shipBase.TakeDamage(environmentBase.CosmoWhaleObstacle);
                if (shipBase.IsShipDead)
                {
                    break;
                }
            }
        }
    }
}