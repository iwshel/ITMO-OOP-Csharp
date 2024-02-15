using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class CreateStella
{
    public CreateStella()
    {
        var regularEngineClassE = new RegularEngineClassE();
        var jumpEngineOmega = new JumpEngineOmega();
        var engineBase = new EngineBase(jumpEngineOmega, regularEngineClassE);
        var deflectorClass1 = new DeflectorClass1();
        var shellClass1 = new ShellClass1();
        var weightOverallCharacteristics =
            new WeightOverallCharacteristics(AllConstants.Type1);

        Ship = new ShipBase(
            engineBase,
            deflectorClass1,
            shellClass1,
            weightOverallCharacteristics,
            AllConstants.FuelCapacityType1WeightShip,
            false);
    }

    public ShipBase Ship { get; private set; }
}