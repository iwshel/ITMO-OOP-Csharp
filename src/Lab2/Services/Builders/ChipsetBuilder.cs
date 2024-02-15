using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Profiles;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class ChipsetBuilder
{
    private string? _wifiStandard;
    private int _memoryFrequency;
    private XmpProfile? _xmp;
    private DocpProfile? _docpProfile;
    private string? _name;

    public ChipsetBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ChipsetBuilder AddWifiStandard(string wifi)
    {
        _wifiStandard = wifi;
        return this;
    }

    public ChipsetBuilder WithMemoryFrequency(int frequency)
    {
        _memoryFrequency = frequency;
        return this;
    }

    public ChipsetBuilder AddXmpProfile(XmpProfile profile)
    {
        _xmp = profile;
        return this;
    }

    public ChipsetBuilder AddDocpProfile(DocpProfile profile)
    {
        _docpProfile = profile;
        return this;
    }

    public Chipset Build()
    {
        return new Chipset(_name ?? throw new ArgumentNullException(nameof(_name)), _wifiStandard, _memoryFrequency, _xmp, _docpProfile);
    }
}