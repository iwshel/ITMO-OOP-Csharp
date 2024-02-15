using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;

public class Gpu : IComponent
{
    public Gpu(
        string name,
        int length,
        int width,
        int amountOfMemory,
        PciExpressSlot pciExpress,
        int frequency,
        int powerConsumption)
    {
        Name = name;
        Length = length > 0 ? length : throw new NegativeLengthException(nameof(length));
        Width = width > 0 ? width : throw new NegativeLengthException(nameof(width));
        AmountOfMemory = amountOfMemory > 0
            ? amountOfMemory
            : throw new NegativeAmountOfStorageException(nameof(amountOfMemory));
        PciExpress = pciExpress ?? throw new ArgumentNullException(nameof(pciExpress));
        Frequency = frequency > 0 ? frequency : throw new NegativeFrequencyException(nameof(frequency));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new NegativePowerConsumptionException(nameof(powerConsumption));
    }

    public Gpu()
    {
        Name = string.Empty;
        PciExpress = new PciExpressSlot(string.Empty, 0);
    }

    public string Name { get; }
    public GpuBuilder Builder => new GpuBuilder();
    public int Length { get; }
    public int Width { get; }
    public int AmountOfMemory { get; }
    public PciExpressSlot PciExpress { get; }
    public int Frequency { get; }
    public int PowerConsumption { get; }

    public GpuBuilder Direct(GpuBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithLength(Length);
        builder.WithWidth(Width);
        builder.WithAmountOfMemory(AmountOfMemory);
        builder.WithPciExpress(PciExpress);
        builder.WithFrequency(Frequency);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}