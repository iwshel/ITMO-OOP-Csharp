using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class BiosBuilder
{
    private string? _type;
    private string? _version;
    private IList<Cpu>? _availableCpu;

    public BiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public BiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public BiosBuilder WithAvailableCpu(IList<Cpu> availableCpu)
    {
        _availableCpu = availableCpu;
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _availableCpu ?? throw new ArgumentNullException(nameof(_availableCpu)));
    }
}