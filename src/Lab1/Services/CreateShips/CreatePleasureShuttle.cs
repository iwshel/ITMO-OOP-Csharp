using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class CreatePleasureShuttle
{
    public CreatePleasureShuttle()
    {
        var regularEngineClassC = new RegularEngineClassC();
        var engineBase = new EngineBase(null, regularEngineClassC);
        var shellClass1 = new ShellClass1();
        var weightOverallCharacteristics =
            new WeightOverallCharacteristics(AllConstants.Type1);

        Ship = new ShipBase(
            engineBase,
            null,
            shellClass1,
            weightOverallCharacteristics,
            AllConstants.FuelCapacityType1WeightShip,
            false);
    }

    public ShipBase Ship { get; private set; }
}