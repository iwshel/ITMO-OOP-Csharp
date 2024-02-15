using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class JumpEngineOmega : JumpEngineBase
{
    public JumpEngineOmega()
        : base(AllConstants.MaxDistanceForJumpEngineOmega, AllConstants.FuelForJumpEngine)
    {
        CorrectEnvironments.Add(new NebulaeOfIncreasedDensityOfSpaceEnvironment());
    }

    public override bool CheckLength(double length)
    {
        if (length > AllConstants.MaxDistanceForJumpEngineOmega)
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

        if (environmentBase.Length <= AllConstants.MaxDistanceForJumpEngineOmega)
        {
            resultOfRoute.Time += environmentBase.Length / AllConstants.SpeedOfJumpEngine;
            for (int j = 1; j < environmentBase.Length; j++)
            {
                resultOfRoute.Time += AllConstants.FuelForJumpEngine * int.Log2(j);
            }
        }
    }
}