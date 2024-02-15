using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class CreateAvgur
{
    public CreateAvgur()
    {
        var regularEngineClassE = new RegularEngineClassE();
        var jumpEngineAlpha = new JumpEngineAlpha();
        var engineBase = new EngineBase(jumpEngineAlpha, regularEngineClassE);
        var deflectorClass3 = new DeflectorClass3();
        var shellClass3 = new ShellClass3();
        var weightOverallCharacteristics =
            new WeightOverallCharacteristics(AllConstants.Type3);

        Ship = new ShipBase(
            engineBase,
            deflectorClass3,
            shellClass3,
            weightOverallCharacteristics,
            AllConstants.FuelCapacityType3WeightShip,
            false);
    }

    public ShipBase Ship { get; private set; }
}