using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class JumpEngineGamma : JumpEngineBase
{
    public JumpEngineGamma()
        : base(AllConstants.MaxDistanceForJumpEngineGamma, AllConstants.FuelForJumpEngine)
    {
        CorrectEnvironments.Add(new NebulaeOfIncreasedDensityOfSpaceEnvironment());
    }

    public override bool CheckLength(double length)
    {
        if (length > AllConstants.MaxDistanceForJumpEngineGamma)
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

        if (environmentBase.Length <= AllConstants.MaxDistanceForJumpEngineGamma)
        {
            resultOfRoute.Time += environmentBase.Length / AllConstants.SpeedOfJumpEngine;
            for (int j = 1; j < environmentBase.Length; j++)
            {
                resultOfRoute.Fuel += AllConstants.FuelForJumpEngine + (j * j);
            }
        }
    }
}