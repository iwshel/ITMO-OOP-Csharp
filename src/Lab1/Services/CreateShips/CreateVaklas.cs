using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class CreateVaklas
{
    public CreateVaklas()
    {
        var regularEngineClassE = new RegularEngineClassE();
        var jumpEngineGamma = new JumpEngineGamma();
        var engineBase = new EngineBase(jumpEngineGamma, regularEngineClassE);
        var deflectorClass1 = new DeflectorClass1();
        var shellClass2 = new ShellClass2();
        var weightOverallCharacteristics = new WeightOverallCharacteristics(AllConstants.Type2);

        Ship = new ShipBase(
            engineBase,
            deflectorClass1,
            shellClass2,
            weightOverallCharacteristics,
            AllConstants.FuelCapacityType2WeightShip,
            false);
    }

    public ShipBase Ship { get; private set; }
}