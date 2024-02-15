using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ProcessResults
{
    public ProcessResults()
    {
        Results = string.Empty;
    }

    public string Results { get; private set; }

    public void Process(ResultOfRoute resultOfRoute)
    {
        if (resultOfRoute is null)
        {
            throw new ArgumentNullException(nameof(resultOfRoute));
        }

        if (resultOfRoute.IsSucceed)
        {
            Results = $"time: {resultOfRoute.Time}, fuel: {resultOfRoute.Fuel}";
            return;
        }

        Results = $"is ship and crew dead: {resultOfRoute.IsShipAndCrewIsDead}\n" +
                  $"is crew dead: {resultOfRoute.IsOnlyCrewDead}\n" +
                  $"is correct engine: {resultOfRoute.IsCorrectEngine}\n" +
                  $"is enough fuel capacity: {resultOfRoute.IsEnoughFuelCapacity}\n";
    }
}