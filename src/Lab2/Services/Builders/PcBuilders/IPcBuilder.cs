using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;

public interface IPcBuilder
{
    IPcCpuBuilder WithMotherboardName(string motherboardName);
}

public interface IPcCpuBuilder
{
    IPcCpuCoolingSystemBuilder WithCpuName(string cpuName);
}

public interface IPcCpuCoolingSystemBuilder
{
    IPcRamBuilder WithCpuCoolingSystem(string cpuCoolingSystemName);
}

public interface IPcRamBuilder
{
    IPcGpuBuilder WithRam(IReadOnlyCollection<string> ramName);
}

public interface IPcGpuBuilder
{
    IPcSsdBuilder WithGpuName(string gpuName);
}

public interface IPcSsdBuilder
{
    IPcHddBuilder WithSsd(IReadOnlyCollection<string> ssdName);
}

public interface IPcHddBuilder
{
    IPcCaseBuilder WithHdd(IReadOnlyCollection<string> hddName);
}

public interface IPcCaseBuilder
{
    IPcPowerUnitBuilder WithPcCaseName(string pcCaseName);
}

public interface IPcPowerUnitBuilder
{
    IPcWiFiAdapterBuilder WithPowerUnitName(string powerUnitName);
}

public interface IPcWiFiAdapterBuilder
{
    IPcBuilder WithWiFiAdapterName(string wiFiAdapterName);
    PersonalComputer Build();
}