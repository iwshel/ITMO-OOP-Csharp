using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStorageRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class HddBuilder
{
    private int _amountOfStorage;
    private int _speedOfSpindle;
    private int _powerConsumption;
    private string? _name;

    public HddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public HddBuilder WithStorage(int amountOfStorage)
    {
        _amountOfStorage = amountOfStorage;
        return this;
    }

    public HddBuilder WithSpeedOfSpindle(int speedOfSpindle)
    {
        _speedOfSpindle = speedOfSpindle;
        return this;
    }

    public HddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(_name ?? throw new ArgumentNullException(nameof(_name)), _amountOfStorage, _speedOfSpindle, _powerConsumption);
    }
}