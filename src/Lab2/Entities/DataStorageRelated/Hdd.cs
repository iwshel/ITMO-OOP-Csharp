using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStorageRelated;

public class Hdd : IComponent
{
    public Hdd(string name, int amountOfStorage, int speedOfSpindle, int powerConsumption)
    {
        Name = name;
        AmountOfStorage = amountOfStorage > 0
            ? amountOfStorage
            : throw new NegativeAmountOfStorageException(nameof(amountOfStorage));
        SpeedOfSpindle = speedOfSpindle > 0 ? speedOfSpindle : throw new NegativeSpeedException(nameof(speedOfSpindle));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new NegativePowerConsumptionException(nameof(powerConsumption));
    }

    public Hdd()
    {
        Name = string.Empty;
    }

    public string Name { get; }
    public HddBuilder Builder => new HddBuilder();
    public int AmountOfStorage { get; }
    public int SpeedOfSpindle { get; }
    public int PowerConsumption { get; }

    public HddBuilder Direct(HddBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithStorage(AmountOfStorage);
        builder.WithSpeedOfSpindle(SpeedOfSpindle);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}