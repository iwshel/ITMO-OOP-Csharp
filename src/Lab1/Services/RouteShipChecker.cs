using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Exeptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class RouteShipChecker
{
    private ResultOfRoute Result { get; } = new();

    public ResultOfRoute CheckRoute(Route route, ShipBase ship)
    {
        if (route is null)
        {
            throw new ArgumentNullException(nameof(route));
        }

        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (route.Environments is null)
        {
            throw new ArgumentNullException(nameof(route));
        }

        if (route.Environments.Count == 0)
        {
            throw new EmptyRouteException("route must contain >= 1 environment");
        }

        foreach (EnvironmentBase curEnvironment in route.Environments)
        {
            Result.IsCorrectEngine = curEnvironment.CheckEngine(ship);
            curEnvironment.TakeShip(ship, curEnvironment, Result);

            Result.IsEnoughFuelCapacity = Result.Fuel <= ship.FuelCapacity;
            Result.IsShipAndCrewIsDead = ship.IsShipDead;
            Result.IsOnlyCrewDead = !ship.IsShipDead && ship.IsCrewDead;

            Result.IsSucceed = Result.IsCorrectEngine && Result.IsEnoughFuelCapacity && !Result.IsShipAndCrewIsDead &&
                !Result.IsOnlyCrewDead;

            if (!Result.IsSucceed)
            {
                return Result;
            }
        }

        return Result;
    }
}