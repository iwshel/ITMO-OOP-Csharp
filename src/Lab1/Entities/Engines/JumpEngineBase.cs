using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class JumpEngineBase
{
    protected JumpEngineBase(double maxDistance, double fuelConsumption)
    {
        if (maxDistance < 0)
        {
            throw new ArgumentException("jump engine max distance must be positive", nameof(maxDistance));
        }

        if (fuelConsumption < 0)
        {
            throw new ArgumentException("jump engine fuelConsumption must be positive", nameof(fuelConsumption));
        }

        MaxDistance = maxDistance;
        FuelConsumption = fuelConsumption;
        CorrectEnvironments = new Collection<EnvironmentBase>();
    }

    public double MaxDistance { get; private set; }

    public double FuelConsumption { get; private set; }

    protected IList<EnvironmentBase> CorrectEnvironments { get; }

    public abstract bool CheckLength(double length);
    public abstract void GoIntoEnvironment(EnvironmentBase environmentBase, ResultOfRoute resultOfRoute);

    public void AddNewEnvironment(EnvironmentBase environment)
    {
        CorrectEnvironments.Add(environment);
    }

    public bool CheckIsEngineCorrect(EnvironmentBase nameOfEnvironment)
    {
        if (MaxDistance == 0)
        {
            return false;
        }

        if (nameOfEnvironment is null)
        {
            throw new ArgumentNullException(nameof(nameOfEnvironment));
        }

        foreach (EnvironmentBase curEnvironment in CorrectEnvironments)
        {
            Type first = curEnvironment.GetType();
            Type second = nameOfEnvironment.GetType();
            if (first == second)
            {
                return true;
            }
        }

        return false;
    }
}