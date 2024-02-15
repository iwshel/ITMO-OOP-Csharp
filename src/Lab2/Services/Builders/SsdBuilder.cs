using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStorageRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class SsdBuilder
{
    private PciExpressSlot? _pciExpress;
    private SataType? _ssdSataType;
    private int _amountOfStorage;
    private int _speedOfReading;
    private int _speedOfWriting;
    private int _powerConsumption;
    private string? _name;

    public SsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public SsdBuilder AddPciExpress(PciExpressSlot pciExpress)
    {
        _pciExpress = pciExpress;
        return this;
    }

    public SsdBuilder AddSata(SataType ssdSataType)
    {
        _ssdSataType = ssdSataType;
        return this;
    }

    public SsdBuilder WithStorage(int amountOfStorage)
    {
        _amountOfStorage = amountOfStorage;
        return this;
    }

    public SsdBuilder WithSpeedOfReading(int speedOfReading)
    {
        _speedOfReading = speedOfReading;
        return this;
    }

    public SsdBuilder WithSpeedOfWriting(int speedOfWriting)
    {
        _speedOfWriting = speedOfWriting;
        return this;
    }

    public SsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Build()
    {
        return new Entities.DataStorageRelated.Ssd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _pciExpress,
            _ssdSataType,
            _amountOfStorage,
            _speedOfReading,
            _speedOfWriting,
            _powerConsumption);
    }
}