using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;

public class WiFiAdapter : IComponent
{
    public WiFiAdapter(string name, string wiFiStandard, string? bluetooth, PciExpressSlot pciExpress, int powerConsumption)
    {
        wiFiStandard = wiFiStandard ?? throw new ArgumentNullException(nameof(wiFiStandard));

        Name = name;
        WiFiStandard = wiFiStandard.Length != 0 ? wiFiStandard : throw new EmptyTypeException(nameof(wiFiStandard));
        Bluetooth = bluetooth;
        PciExpress = pciExpress ?? throw new ArgumentNullException(nameof(pciExpress));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new NegativePowerConsumptionException(nameof(powerConsumption));
    }

    public WiFiAdapter()
    {
        Name = string.Empty;
        WiFiStandard = string.Empty;
        PciExpress = new PciExpressSlot(string.Empty, 0);
    }

    public WiFiAdapterBuilder Builder => new WiFiAdapterBuilder();
    public string Name { get; }
    public string WiFiStandard { get; }
    public string? Bluetooth { get; }
    public PciExpressSlot PciExpress { get; }
    public int PowerConsumption { get; }

    public WiFiAdapterBuilder Direct(WiFiAdapterBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithName(Name);
        builder.WithWiFiStandard(WiFiStandard);
        if (Bluetooth is not null) builder.WithBluetooth(Bluetooth);
        builder.WithPciExpressSlot(PciExpress);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}