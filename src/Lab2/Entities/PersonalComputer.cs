using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStorageRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PersonalComputer
{
    public PersonalComputer(
        Motherboard pcMotherboard,
        Cpu pcCpu,
        CpuCoolingSystem pcCpuCoolingSystem,
        IReadOnlyCollection<Ram> pcRam,
        PcCase pcCase,
        PowerUnit pcPowerUnit,
        Gpu pcGpu,
        IReadOnlyCollection<Ssd> pcSsd,
        IReadOnlyCollection<Hdd> pcHdd,
        WiFiAdapter pcWiFiAdapter)
    {
        pcRam = pcRam ?? throw new ArgumentNullException(nameof(pcRam));
        pcSsd = pcSsd ?? throw new ArgumentNullException(nameof(pcSsd));
        pcHdd = pcHdd ?? throw new ArgumentNullException(nameof(pcHdd));

        PcMotherboard = pcMotherboard ?? throw new ArgumentNullException(nameof(pcMotherboard));
        PcCpu = pcCpu ?? throw new ArgumentNullException(nameof(pcCpu));
        PcCpuCoolingSystem = pcCpuCoolingSystem ?? throw new ArgumentNullException(nameof(pcCpuCoolingSystem));
        PcRam = pcRam.Count > 0 ? pcRam : throw new EmptyCollectionException(nameof(pcRam));
        CasePc = pcCase ?? throw new ArgumentNullException(nameof(pcCase));
        PcPowerUnit = pcPowerUnit ?? throw new ArgumentNullException(nameof(pcPowerUnit));

        PcGpu = pcGpu;
        PcSsd = pcSsd;
        PcHdd = pcHdd;
        PcWiFiAdapter = pcWiFiAdapter;
    }

    public PersonalComputer()
    {
        PcMotherboard = new Motherboard();
        PcCpu = new Cpu();
        PcCpuCoolingSystem = new CpuCoolingSystem();
        PcRam = new List<Ram>();
        PcHdd = new List<Hdd>();
        PcGpu = new Gpu();
        PcSsd = new List<Ssd>();
        CasePc = new PcCase();
        PcPowerUnit = new PowerUnit(string.Empty, 0);
        PcWiFiAdapter = new WiFiAdapter();
    }

    public Motherboard PcMotherboard { get; }
    public Cpu PcCpu { get; }
    public CpuCoolingSystem PcCpuCoolingSystem { get; }
    public IReadOnlyCollection<Ram> PcRam { get; }
    public PcCase CasePc { get; }
    public PowerUnit PcPowerUnit { get; }
    public Gpu PcGpu { get; }
    public IReadOnlyCollection<Ssd> PcSsd { get; }
    public IReadOnlyCollection<Hdd> PcHdd { get; }
    public WiFiAdapter PcWiFiAdapter { get; }

    public IPcBuilder Direct(IPcBuilder builder)
    {
        var rams = new Collection<string>();

        foreach (Ram curRam in PcRam)
        {
            rams.Add(curRam.Name);
        }

        var ssds = new Collection<string>();
        var hdds = new Collection<string>();

        foreach (Ssd curSsd in PcSsd)
        {
            ssds.Add(curSsd.Name);
        }

        foreach (Hdd curHdd in PcHdd)
        {
            hdds.Add(curHdd.Name);
        }

        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithMotherboardName(PcMotherboard.Name)
            .WithCpuName(PcCpu.Name)
            .WithCpuCoolingSystem(PcCpuCoolingSystem.Name)
            .WithRam(rams)
            .WithGpuName(PcGpu.Name)
            .WithSsd(ssds)
            .WithHdd(hdds)
            .WithPcCaseName(CasePc.Name)
            .WithPowerUnitName(PcPowerUnit.Name)
            .WithWiFiAdapterName(PcWiFiAdapter.Name);

        return builder;
    }

    public bool CheckTdp()
    {
        return PcCpu.Tdp <= PcCpuCoolingSystem.MaxTdp;
    }

    public bool CheckVoltage()
    {
        const int maxVoltageDifference = 200;
        int voltage = PcCpu.PowerConsumption + PcRam.Sum(curRam => curRam.PowerConsumption)
                                             + PcSsd.Sum(curSsd => curSsd.PowerConsumption) +
                                             PcHdd.Sum(curHdd => curHdd.PowerConsumption);

        voltage += PcGpu.PowerConsumption;

        voltage += PcWiFiAdapter.PowerConsumption;

        return PcPowerUnit.PeakLoad - voltage > maxVoltageDifference;
    }
}