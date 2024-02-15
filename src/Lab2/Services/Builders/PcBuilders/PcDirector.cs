using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;

public class PcDirector
{
    private readonly Specifications _specifications;
    private readonly PcBuilder _pcBuilder;

    public PcDirector(PcBuilder pcBuilder, Specifications specifications)
    {
        _pcBuilder = pcBuilder ?? throw new ArgumentNullException(nameof(pcBuilder));
        _specifications = specifications ?? throw new ArgumentNullException(nameof(specifications));
    }

    public PersonalComputer Direct()
    {
        _pcBuilder
            .WithMotherboardName(_specifications.MotherboardName)
            .WithCpuName(_specifications.CpuName)
            .WithCpuCoolingSystem(_specifications.CpuCoolingSystemName)
            .WithRam(_specifications.RamName);

        if (!string.IsNullOrEmpty(_specifications.GpuName)) _pcBuilder.WithGpuName(_specifications.GpuName);
        _pcBuilder.WithSsd(_specifications.SsdName);
        _pcBuilder.WithHdd(_specifications.HddName);
        if (!string.IsNullOrEmpty(_specifications.WiFiAdapterName))
            _pcBuilder.WithWiFiAdapterName(_specifications.WiFiAdapterName);
        _pcBuilder.WithPowerUnitName(_specifications.PowerUnitName);
        _pcBuilder.WithPcCaseName(_specifications.PcCaseName);

        return _pcBuilder.Build();
    }
}