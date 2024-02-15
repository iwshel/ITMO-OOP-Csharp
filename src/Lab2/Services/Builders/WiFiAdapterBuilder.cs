using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class WiFiAdapterBuilder
{
    private string? _wiFiStandard;
    private string? _bluetooth;
    private PciExpressSlot? _pciExpress;
    private int _powerConsumption;
    private string _name = string.Empty;

    public WiFiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WiFiAdapterBuilder WithWiFiStandard(string wiFiStandard)
    {
        _wiFiStandard = wiFiStandard;
        return this;
    }

    public WiFiAdapterBuilder WithBluetooth(string bluetooth)
    {
        _bluetooth = bluetooth;
        return this;
    }

    public WiFiAdapterBuilder WithPciExpressSlot(PciExpressSlot pciExpress)
    {
        _pciExpress = pciExpress;
        return this;
    }

    public WiFiAdapterBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _wiFiStandard ?? throw new ArgumentNullException(nameof(_wiFiStandard)),
            _bluetooth,
            _pciExpress ?? throw new ArgumentNullException(nameof(_pciExpress)),
            _powerConsumption);
    }
}