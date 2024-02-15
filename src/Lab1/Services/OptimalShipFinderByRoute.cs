using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class OptimalShipFinderByRoute
{
    public ShipBase? FinalShip { get; private set; }

    public ShipBase? FindBestShip(Route route, IList<ShipBase> allShips)
    {
        if (route is null)
        {
            throw new ArgumentNullException(nameof(route));
        }

        if (allShips is null)
        {
            throw new ArgumentNullException(nameof(allShips));
        }

        double minFuel = double.MaxValue;
        foreach (ShipBase curShip in allShips)
        {
            var routeShipChecker = new RouteShipChecker();
            Route tempRoute = route;
            ResultOfRoute resultOfCurRoute = routeShipChecker.CheckRoute(tempRoute, curShip);

            if (resultOfCurRoute.IsSucceed)
            {
                if (minFuel > resultOfCurRoute.Fuel)
                {
                    FinalShip = curShip;
                    minFuel = resultOfCurRoute.Fuel;
                }
            }
        }

        return FinalShip;
    }
}