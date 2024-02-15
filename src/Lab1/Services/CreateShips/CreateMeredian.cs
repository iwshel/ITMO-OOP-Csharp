using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class CreateMeredian
{
    public CreateMeredian()
    {
        var regularEngineClassE = new RegularEngineClassE();
        var engineBase = new EngineBase(null, regularEngineClassE);
        var deflectorClass2 = new DeflectorClass2();
        var shellClass2 = new ShellClass2();
        var weightOverallCharacteristics =
            new WeightOverallCharacteristics(AllConstants.Type2);

        Ship = new ShipBase(
            engineBase,
            deflectorClass2,
            shellClass2,
            weightOverallCharacteristics,
            AllConstants.FuelCapacityType2WeightShip,
            true);
    }

    public ShipBase Ship { get; private set; }
}