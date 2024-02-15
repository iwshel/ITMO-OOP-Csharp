using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class RegularEngineBase
{
    protected RegularEngineBase(double speed, double fuelConsumption)
    {
        if (speed < 0)
        {
            throw new ArgumentException("engine max distance must be positive", nameof(speed));
        }

        if (fuelConsumption < 0)
        {
            throw new ArgumentException("engine fuelConsumption must be positive", nameof(fuelConsumption));
        }

        Speed = speed;
        FuelConsumption = fuelConsumption;
        CorrectEnvironments = new Collection<EnvironmentBase>();
    }

    public double Speed { get; private set; }

    public double FuelConsumption { get; private set; }

    protected IList<EnvironmentBase> CorrectEnvironments { get; }

    public abstract void GoIntoEnvironment(EnvironmentBase environmentBase, ResultOfRoute resultOfRoute);

    public void AddNewEnvironment(EnvironmentBase environment)
    {
        CorrectEnvironments.Add(environment);
    }

    public bool CheckIsEngineCorrect(EnvironmentBase nameOfEnvironment)
    {
        if (Speed == 0)
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