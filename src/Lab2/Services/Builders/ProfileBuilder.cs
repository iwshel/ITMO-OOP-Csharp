using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Profiles;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class ProfileBuilder
{
    private IReadOnlyCollection<int>? _timings;
    private int _voltage;
    private int _frequency;
    private string? _name;

    public ProfileBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProfileBuilder WithTimings(IReadOnlyCollection<int> timings)
    {
        _timings = timings;
        return this;
    }

    public ProfileBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public ProfileBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XmpProfile BuildXmpProfile()
    {
        return new XmpProfile(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _voltage,
            _frequency);
    }

    public DocpProfile BuildDocpProfile()
    {
        return new DocpProfile(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _voltage,
            _frequency);
    }
}