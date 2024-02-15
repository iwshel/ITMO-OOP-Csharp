using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStorageRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositorys;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;

public class PcBuilder : IPcBuilder, IPcCpuBuilder, IPcCpuCoolingSystemBuilder, IPcRamBuilder, IPcGpuBuilder,
    IPcSsdBuilder, IPcHddBuilder, IPcCaseBuilder, IPcPowerUnitBuilder, IPcWiFiAdapterBuilder
{
    private const int MaxVoltageDifference = 200;

    private readonly IRepository<CpuCoolingSystem> _cpuCoolingSystemRepositoryOfComponents;
    private readonly IRepository<Gpu> _gpuRepositoryOfComponents;
    private readonly IRepository<PcCase> _pcCaseRepositoryOfComponents;
    private readonly IRepository<PowerUnit> _powerUnitRepositoryOfComponents;
    private readonly IRepository<Cpu> _cpuRepositoryOfComponents;
    private readonly IRepository<Ssd> _ssdRepositoryOfComponents;
    private readonly IRepository<Hdd> _hddRepositoryOfComponents;
    private readonly IRepository<Motherboard> _motherboardRepositoryOfComponents;
    private readonly IRepository<Ram> _ramRepositoryOfComponents;
    private readonly IRepository<WiFiAdapter> _wifiRepositoryOfComponents;

    private Motherboard _pcMotherboard = new Motherboard();
    private Cpu _pcCpu = new Cpu();
    private CpuCoolingSystem _pcCpuCoolingSystem = new CpuCoolingSystem();
    private Collection<Ram> _pcRam = new Collection<Ram>();
    private PcCase _casePc = new PcCase();
    private PowerUnit _pcPowerUnit = new PowerUnit();

    private Gpu _pcGpu = new Gpu();
    private Collection<Ssd> _pcSsd = new Collection<Ssd>();
    private Collection<Hdd> _pcHdd = new Collection<Hdd>();
    private WiFiAdapter _pcWiFiAdapter = new WiFiAdapter();

    public PcBuilder(
        IRepository<CpuCoolingSystem> cpuCoolingSystemRepositoryOfComponents,
        IRepository<Gpu> gpuRepositoryOfComponents,
        IRepository<PcCase> pcCaseRepositoryOfComponents,
        IRepository<PowerUnit> powerUnitRepositoryOfComponents,
        IRepository<Cpu> cpuRepositoryOfComponents,
        IRepository<Ssd> ssdRepositoryOfComponents,
        IRepository<Hdd> hddRepositoryOfComponents,
        IRepository<Motherboard> motherboardRepositoryOfComponents,
        IRepository<Ram> ramRepositoryOfComponents,
        IRepository<WiFiAdapter> wifiRepositoryOfComponents)
    {
        _cpuCoolingSystemRepositoryOfComponents = cpuCoolingSystemRepositoryOfComponents;
        _gpuRepositoryOfComponents = gpuRepositoryOfComponents;
        _pcCaseRepositoryOfComponents = pcCaseRepositoryOfComponents;
        _powerUnitRepositoryOfComponents = powerUnitRepositoryOfComponents;
        _cpuRepositoryOfComponents = cpuRepositoryOfComponents;
        _ssdRepositoryOfComponents = ssdRepositoryOfComponents;
        _hddRepositoryOfComponents = hddRepositoryOfComponents;
        _motherboardRepositoryOfComponents = motherboardRepositoryOfComponents;
        _ramRepositoryOfComponents = ramRepositoryOfComponents;
        _wifiRepositoryOfComponents = wifiRepositoryOfComponents;
        Results = new Collection<AssemblyResult>();
    }

    public Collection<AssemblyResult> Results { get; private set; }

    public IPcCpuBuilder WithMotherboardName(string motherboardName)
    {
        _pcMotherboard = _motherboardRepositoryOfComponents.FindByName(motherboardName);
        return this;
    }

    public IPcCpuCoolingSystemBuilder WithCpuName(string cpuName)
    {
        _pcCpu = _cpuRepositoryOfComponents.FindByName(cpuName);

        if (!_pcCpu.Socket.Equals(_pcMotherboard.MotherboardSocket))
        {
            Results.Add(new AssemblyResult.AssemblyFailWrongSocket());
        }

        if (!_pcMotherboard.MotherboardBios.IsAvailableCpu(_pcCpu))
        {
            Results.Add(new AssemblyResult.AssemblyFailNotAvailableCpu());
        }

        return this;
    }

    public IPcRamBuilder WithCpuCoolingSystem(string cpuCoolingSystemName)
    {
        _pcCpuCoolingSystem = _cpuCoolingSystemRepositoryOfComponents.FindByName(cpuCoolingSystemName);

        if (!_pcCpuCoolingSystem.IsCorrectSocket(_pcCpu.Socket))
        {
            Results.Add(new AssemblyResult.AssemblyFailWrongCoolingSystemSocket());
        }

        return this;
    }

    public IPcGpuBuilder WithRam(IReadOnlyCollection<string> ramName)
    {
        ramName = ramName ?? throw new ArgumentNullException(nameof(ramName));

        foreach (string curRam in ramName)
        {
            _pcRam.Add(_ramRepositoryOfComponents.FindByName(curRam));
        }

        foreach (Ram curRam in _pcRam)
        {
            if (!_pcMotherboard.MotherboardDdrStandard.Equals(curRam.RamDdrStandard))
            {
                Results.Add(new AssemblyResult.AssemblyFailWrongDdrStandard());
            }

            if (!_pcMotherboard.MotherboardRamConnector.ConnectNewRam())
            {
                Results.Add(new AssemblyResult.AssemblyFailNotEnoughRamSlots());
            }
        }

        return this;
    }

    public IPcSsdBuilder WithGpuName(string gpuName)
    {
        _pcGpu = _gpuRepositoryOfComponents.FindByName(gpuName);

        if (_pcMotherboard.MotherboardPciExpress.Slots.Where(curSlot => _pcGpu.PciExpress.Equals(curSlot))
            .Any(curSlot => !curSlot.SetNewDevice()))
        {
            Results.Add(new AssemblyResult.AssemblyFailNotEnoughPciESlots());
        }

        return this;
    }

    public IPcHddBuilder WithSsd(IReadOnlyCollection<string> ssdName)
    {
        ssdName = ssdName ?? throw new ArgumentNullException(nameof(ssdName));

        foreach (string curSsd in ssdName)
        {
            _pcSsd.Add(_ssdRepositoryOfComponents.FindByName(curSsd));
        }

        foreach (Ssd curSsd in _pcSsd)
        {
            if (curSsd.SsdSataType is not null)
            {
                if (!_pcMotherboard.MotherboardSata.SetNewInformationStorageDevice())
                {
                    Results.Add(new AssemblyResult.AssemblyFailNotEnoughSataSlots());
                }
            }

            if (curSsd.PciExpress is not null)
            {
                if (_pcMotherboard.MotherboardPciExpress.Slots.Where(curSlot => curSsd.PciExpress.Equals(curSlot))
                    .Any(curSlot => !curSlot.SetNewDevice()))
                {
                    Results.Add(new AssemblyResult.AssemblyFailNotEnoughPciESlots());
                }
            }
        }

        return this;
    }

    public IPcCaseBuilder WithHdd(IReadOnlyCollection<string> hddName)
    {
        hddName = hddName ?? throw new ArgumentNullException(nameof(hddName));

        foreach (string curHdd in hddName)
        {
            _pcHdd.Add(_hddRepositoryOfComponents.FindByName(curHdd));
        }

        for (int i = 0; i < _pcHdd.Count; i++)
        {
            if (!_pcMotherboard.MotherboardSata.SetNewInformationStorageDevice())
            {
                Results.Add(new AssemblyResult.AssemblyFailNotEnoughSataSlots());
            }
        }

        return this;
    }

    public IPcPowerUnitBuilder WithPcCaseName(string pcCaseName)
    {
        _casePc = _pcCaseRepositoryOfComponents.FindByName(pcCaseName);

        if (_casePc.MaxLengthGpu < _pcGpu.Length || _casePc.MaxWidthGpu < _pcGpu.Width)
        {
            Results.Add(new AssemblyResult.AssemblyFailIncorrectSizeGpu());
        }

        if (!_casePc.IsCorrectFormFactor(_pcMotherboard.FormFactor))
        {
            Results.Add(new AssemblyResult.AssemblyFailIncorrectMotherboardFormFactor());
        }

        return this;
    }

    public IPcBuilder WithWiFiAdapterName(string wiFiAdapterName)
    {
        _pcWiFiAdapter = _wifiRepositoryOfComponents.FindByName(wiFiAdapterName);

        if (_pcMotherboard.MotherboardChipset.WifiStandard is not null)
        {
            Results.Add(new AssemblyResult.AssemblyFailConflictWifi());
        }

        if (_pcMotherboard.MotherboardPciExpress.Slots.Where(curSlot => _pcWiFiAdapter.PciExpress.Equals(curSlot))
            .Any(curSlot => !curSlot.SetNewDevice()))
        {
            Results.Add(new AssemblyResult.AssemblyFailNotEnoughPciESlots());
        }

        return this;
    }

    public IPcWiFiAdapterBuilder WithPowerUnitName(string powerUnitName)
    {
        _pcPowerUnit = _powerUnitRepositoryOfComponents.FindByName(powerUnitName);

        int voltage = _pcCpu.PowerConsumption + _pcRam.Sum(curRam => curRam.PowerConsumption)
                                              + _pcSsd.Sum(curSsd => curSsd.PowerConsumption) +
                                              _pcHdd.Sum(curHdd => curHdd.PowerConsumption);

        voltage += _pcGpu.PowerConsumption;

        voltage += _pcWiFiAdapter.PowerConsumption;

        if (voltage - _pcPowerUnit.PeakLoad > MaxVoltageDifference)
        {
            Results.Add(new AssemblyResult.AssemblyFailVoltageInPowerUnit());
        }

        return this;
    }

    public PersonalComputer Build()
    {
        return new PersonalComputer(
            _pcMotherboard,
            _pcCpu,
            _pcCpuCoolingSystem,
            _pcRam,
            _casePc,
            _pcPowerUnit,
            _pcGpu,
            _pcSsd,
            _pcHdd,
            _pcWiFiAdapter);
    }
}