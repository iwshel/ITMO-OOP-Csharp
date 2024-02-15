using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStorageRelated;

public class Ssd : IComponent
{
    public Ssd(
        string name,
        PciExpressSlot? pciExpress,
        SataType? sataType,
        int amountOfStorage,
        int speedOfReading,
        int speedOfWriting,
        int powerConsumption)
    {
        if (pciExpress is not null && sataType is not null)
        {
            throw new TwoConnectorException("can't be two connectors");
        }

        if (pciExpress is null && sataType is null)
        {
            throw new TwoConnectorException("need one connector");
        }

        Name = name;
        PciExpress = pciExpress;
        SsdSataType = sataType;
        AmountOfStorage = amountOfStorage > 0
            ? amountOfStorage
            : throw new NegativeAmountOfStorageException(nameof(amountOfStorage));
        SpeedOfReading = speedOfReading > 0 ? speedOfReading : throw new NegativeSpeedException(nameof(speedOfReading));
        SpeedOfWriting = speedOfWriting > 0 ? speedOfWriting : throw new NegativeSpeedException(nameof(speedOfWriting));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new NegativePowerConsumptionException(nameof(powerConsumption));
    }

    public Ssd()
    {
        Name = string.Empty;
    }

    public string Name { get; }
    public SsdBuilder Builder => new SsdBuilder();
    public PciExpressSlot? PciExpress { get; }
    public SataType? SsdSataType { get; }
    public int AmountOfStorage { get; }
    public int SpeedOfReading { get; }
    public int SpeedOfWriting { get; }
    public int PowerConsumption { get; }

    public SsdBuilder Direct(SsdBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        if (PciExpress is not null) builder.AddPciExpress(PciExpress);
        if (SsdSataType is not null) builder.AddSata(SsdSataType);
        builder.WithStorage(AmountOfStorage);
        builder.WithSpeedOfReading(SpeedOfReading);
        builder.WithSpeedOfWriting(SpeedOfWriting);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}