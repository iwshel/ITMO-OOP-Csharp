using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Profiles;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class RamBuilder
{
    private int _amountOfStorage;
    private int _jedecVoltage;
    private IReadOnlyCollection<int> _frequency = new List<int>();
    private XmpProfile? _ramXmpProfile;
    private DocpProfile? _ramDocpProfile;
    private RamFormFactor _formFactor = new RamFormFactor(string.Empty);
    private DdrStandard _ramDdrStandard = new DdrStandard(string.Empty);
    private int _powerConsumption;
    private string? _name;

    public RamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public RamBuilder WithAmountOfStorage(int amountOfStorage)
    {
        _amountOfStorage = amountOfStorage;
        return this;
    }

    public RamBuilder WithJdecVoltage(int jdecVoltage)
    {
        _jedecVoltage = jdecVoltage;
        return this;
    }

    public RamBuilder WithFrequency(IReadOnlyCollection<int> frequency)
    {
        _frequency = frequency;
        return this;
    }

    public RamBuilder AddXmpProfile(XmpProfile ramXmpProfile)
    {
        _ramXmpProfile = ramXmpProfile;
        return this;
    }

    public RamBuilder AddDocpProfile(DocpProfile ramDocpProfile)
    {
        _ramDocpProfile = ramDocpProfile;
        return this;
    }

    public RamBuilder WithFormFactor(RamFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder WithDdrStandard(DdrStandard ramDdrStandard)
    {
        _ramDdrStandard = ramDdrStandard;
        return this;
    }

    public RamBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        return new Entities.RamRelated.Ram(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _amountOfStorage,
            _jedecVoltage,
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)),
            _ramXmpProfile,
            _ramDocpProfile,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ramDdrStandard ?? throw new ArgumentNullException(nameof(_ramDdrStandard)),
            _powerConsumption);
    }
}