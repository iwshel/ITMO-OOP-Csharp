using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class RegularEngineClassE : RegularEngineBase
{
    public RegularEngineClassE()
        : base(AllConstants.SpeedOfRegularEngineTypeE, AllConstants.FuelForRegularEngineTypeE)
    {
        CorrectEnvironments.Add(new CosmosEnvironment());
        CorrectEnvironments.Add(new NebulaeOfNitrineParticlesEnvironment());
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
        resultOfRoute.Fuel += AllConstants.FuelForRegularEngineTypeE * environmentBase.Length;
        resultOfRoute.Time += environmentBase.Length / AllConstants.SpeedOfRegularEngineTypeE;
    }
}