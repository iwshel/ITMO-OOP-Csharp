using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ShipBase
{
    public ShipBase(
        EngineBase engine,
        DeflectorBase? deflector,
        ShellBase shell,
        WeightOverallCharacteristics characteristics,
        double fuelCapacity,
        bool antiNitrineEmitter)
    {
        if (fuelCapacity <= 0)
        {
            throw new ArgumentException("fuel capacity must be positive", nameof(fuelCapacity));
        }

        Deflector = deflector ?? new NullDeflector();

        Engine = engine ?? throw new ArgumentNullException(nameof(engine));
        Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        Characteristics = characteristics ?? throw new ArgumentNullException(nameof(characteristics));
        FuelCapacity = fuelCapacity;
        AntiNitrineEmitter = antiNitrineEmitter;
    }

    public EngineBase Engine { get; }

    public ShellBase Shell { get; }

    public DeflectorBase Deflector { get; }

    public WeightOverallCharacteristics Characteristics { get; private set; }

    public double FuelCapacity { get; }

    public bool AntiNitrineEmitter { get; }

    public bool IsShipDead { get; private set; }

    public bool IsCrewDead { get; private set; }

    public void TakeDamage(ObstacleBase? obstacle)
    {
        if (obstacle is null)
        {
            return;
        }

        if (obstacle.PhotonicDamage)
        {
            IsCrewDead = Deflector.TakePhotonicDamage();
        }
        else
        {
            Deflector.TakeDamage(obstacle);
            Shell.TakeDamage(obstacle);

            IsShipDead = Shell.IsShellDead;
            IsCrewDead = Shell.IsShellDead;
        }
    }

    public void SetPhotonicDeflector()
    {
        Deflector.SetPhotonicDeflector();
    }

    public bool IsEnvironmentSupported(EnvironmentBase environment)
    {
        return Engine.RegularEngine.CheckIsEngineCorrect(environment) || Engine.JumpEngine.CheckIsEngineCorrect(environment);
    }

    public bool IsLengthCorrect(double length)
    {
        return Engine.JumpEngine.CheckLength(length);
    }

    public void GoToEnvironment(EnvironmentBase environmentBase, ResultOfRoute resultOfRoute)
    {
        Engine.RegularEngine.GoIntoEnvironment(environmentBase, resultOfRoute);
        Engine.JumpEngine.GoIntoEnvironment(environmentBase, resultOfRoute);
    }
}