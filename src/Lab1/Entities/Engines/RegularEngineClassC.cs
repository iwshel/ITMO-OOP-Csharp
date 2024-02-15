using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class RegularEngineClassC : RegularEngineBase
{
    public RegularEngineClassC()
        : base(AllConstants.SpeedOfRegularEngineTypeC, AllConstants.FuelForRegularEngineTypeC)
    {
        CorrectEnvironments.Add(new CosmosEnvironment());
    }

    public override void GoIntoEnvironment(EnvironmentBase environmentBase, ResultOfRoute resultOfRoute)
    {
        if (environmentBase is null)
        {
            throw new ArgumentNullException(nameof(environmentBase));
        }

        if (resultOfRoute is null)
        {
            throw new ArgumentNullException(nameof(resultOfRoute));
        }

        resultOfRoute.Fuel += AllConstants.FuelForStartRegularEngine;
        resultOfRoute.Fuel += AllConstants.FuelForRegularEngineTypeC * environmentBase.Length;
        resultOfRoute.Time += environmentBase.Length / AllConstants.SpeedOfRegularEngineTypeC;
    }
}