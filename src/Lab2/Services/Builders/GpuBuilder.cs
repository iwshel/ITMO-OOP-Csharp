using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class GpuBuilder
{
    private int _length;
    private int _width;
    private int _amountOfMemory;
    private PciExpressSlot? _pciExpress;
    private int _frequency;
    private int _powerConsumption;
    private string? _name;

    public GpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public GpuBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public GpuBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public GpuBuilder WithAmountOfMemory(int amountOfMemory)
    {
        _amountOfMemory = amountOfMemory;
        return this;
    }

    public GpuBuilder WithPciExpress(PciExpressSlot pciExpress)
    {
        _pciExpress = pciExpress;
        return this;
    }

    public GpuBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public GpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Gpu Build()
    {
        return new Gpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _length,
            _width,
            _amountOfMemory,
            _pciExpress ?? throw new ArgumentNullException(nameof(_pciExpress)),
            _frequency,
            _powerConsumption);
    }
}