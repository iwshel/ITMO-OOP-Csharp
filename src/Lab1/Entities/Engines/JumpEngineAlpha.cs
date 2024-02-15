using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class JumpEngineAlpha : JumpEngineBase
{
    public JumpEngineAlpha()
        : base(AllConstants.MaxDistanceForJumpEngineAlpha, AllConstants.FuelForJumpEngine)
    {
        CorrectEnvironments.Add(new NebulaeOfIncreasedDensityOfSpaceEnvironment());
    }

    public override bool CheckLength(double length)
    {
        if (length > AllConstants.MaxDistanceForJumpEngineAlpha)
        {
            return false;
        }

        return true;
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

        if (environmentBase.Length <= AllConstants.MaxDistanceForJumpEngineAlpha)
        {
            resultOfRoute.Time += environmentBase.Length / AllConstants.SpeedOfJumpEngine;
            resultOfRoute.Fuel += environmentBase.Length * AllConstants.FuelForJumpEngine;
        }
    }
}