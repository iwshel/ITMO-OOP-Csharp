using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Profiles;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStorageRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositorys;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerAssemblyTests
{
    private readonly IRepository<CpuCoolingSystem> _cpuCoolingSystemRepositoryOfComponents = new RepositoryOfComponents<CpuCoolingSystem>();
    private readonly IRepository<Gpu> _gpuRepositoryOfComponents = new RepositoryOfComponents<Gpu>();
    private readonly IRepository<PcCase> _pcCaseRepositoryOfComponents = new RepositoryOfComponents<PcCase>();
    private readonly IRepository<PowerUnit> _powerUnitRepositoryOfComponents = new RepositoryOfComponents<PowerUnit>();
    private readonly IRepository<Cpu> _cpuRepositoryOfComponents = new RepositoryOfComponents<Cpu>();
    private readonly IRepository<Ssd> _ssdRepositoryOfComponents = new RepositoryOfComponents<Ssd>();
    private readonly IRepository<Hdd> _hddRepositoryOfComponents = new RepositoryOfComponents<Hdd>();
    private readonly IRepository<Motherboard> _motherboardRepositoryOfComponents = new RepositoryOfComponents<Motherboard>();
    private readonly IRepository<Ram> _ramRepositoryOfComponents = new RepositoryOfComponents<Ram>();
    private readonly IRepository<WiFiAdapter> _wifiRepositoryOfComponents = new RepositoryOfComponents<WiFiAdapter>();
    private readonly PcBuilder _pcBuilder;
    private readonly ComputerFactory _computerFactory;

    public ComputerAssemblyTests()
    {
        _cpuRepositoryOfComponents.AddNew(
            new Cpu(
                "Intel Core i9-13900K",
                3000,
                24,
                new SocketCpu("LGA 1700"),
                new OnBoardVideoProcessor("Intel UHD Graphics 770"),
                5800,
                150,
                125));
        _cpuRepositoryOfComponents.AddNew(
            new Cpu(
                "AMD RYZEN 5 3600 OEM AM4 Matisse",
                3600,
                12,
                new SocketCpu("AM4"),
                null,
                100,
                65,
                70));
        _motherboardRepositoryOfComponents.AddNew(
            new Motherboard(
                "Gigabyte Z790 Aorus Elite AX",
                new SocketCpu("LGA 1700"),
                new PciExpress(new Collection<PciExpressSlot>()
                    { new PciExpressSlot("x16", 3), new PciExpressSlot("x4", 1) }),
                new Sata(6, new SataType("SATA 3")),
                new Chipset("Intel Z790", "Wi-Fi 6E", 20, new XmpProfile("Intel XMP 3.0", new List<int>() { 38, 48, 78, 126 }, 1, 6400), null),
                new DdrStandard("DDR5"),
                new RamConnector(4),
                new MotherboardFormFactor("ATX"),
                new Bios("UEFI BIOS", "UEFI BIOS", new List<Cpu>() { _cpuRepositoryOfComponents.FindByName("Intel Core i9-13900K") })));
        _cpuCoolingSystemRepositoryOfComponents.AddNew(
            new CpuCoolingSystem(
                "DEEPCOOL AK620 ZERO DARK [R-AK620-BKNNMT-G-1]",
                120,
                120,
                new List<SocketCpu>() { new SocketCpu("LGA 1700") },
                260));
        _cpuCoolingSystemRepositoryOfComponents.AddNew(
            new CpuCoolingSystem(
                "ID-COOLING SE-213V2",
                120,
                75,
                new List<SocketCpu>() { new SocketCpu("LGA 1700") },
                130));
        _ramRepositoryOfComponents.AddNew(
            new Ram(
                "32Gb 6000MHz Kingston Fury Beast 2x16Gb KIT CL40 DDR5 (KF560C40BBK2-32)",
                32,
                6000,
                new List<int>() { 40, 40, 40 },
                new XmpProfile("Intel XMP 3.0", new List<int>() { 38, 48, 78, 126 }, 1, 6400),
                null,
                new RamFormFactor("DIMM"),
                new DdrStandard("DDR5"),
                1));
        _gpuRepositoryOfComponents.AddNew(
            new Gpu(
                "Gigabyte GeForce RTX 4090 GAMING OC 24GB (GV-N4090GAMING OC-24GD)",
                340,
                76,
                24,
                new PciExpressSlot("x16", 1),
                2535,
                800));
        _ssdRepositoryOfComponents.AddNew(
            new Ssd(
                "SSD 1Tb Samsung 980 Pro NVMe M.2 (MZ-V8P1T0BW)",
                new PciExpressSlot("x4", 1),
                null,
                1000,
                7000,
                5000,
                2));
        _hddRepositoryOfComponents.AddNew(
            new Hdd(
                "2Tb Seagate Barracuda 5400 rpm (ST2000DM005)",
                2000,
                5400,
                3));
        _pcCaseRepositoryOfComponents.AddNew(
            new PcCase(
                "Be Quiet Pure Base 500DX Black TG BGW37",
                369,
                100,
                new List<MotherboardFormFactor>() { new MotherboardFormFactor("ATX") },
                450,
                232,
                463));
        _powerUnitRepositoryOfComponents.AddNew(
            new PowerUnit(
                "1200W Corsair HX1200i (CP-9020070-EU)",
                1200));
        _powerUnitRepositoryOfComponents.AddNew(
            new PowerUnit(
                "1000W DeepCool PQ1000M Gold (R-PQA00M-FA0B-EU)",
                1000));
        _pcBuilder = new PcBuilder(
            _cpuCoolingSystemRepositoryOfComponents,
            _gpuRepositoryOfComponents,
            _pcCaseRepositoryOfComponents,
            _powerUnitRepositoryOfComponents,
            _cpuRepositoryOfComponents,
            _ssdRepositoryOfComponents,
            _hddRepositoryOfComponents,
            _motherboardRepositoryOfComponents,
            _ramRepositoryOfComponents,
            _wifiRepositoryOfComponents);
        _computerFactory = new ComputerFactory();
    }

    [Fact]
    public void TestBestComputerSuccess()
    {
        // arrange
        var computerAssembly = new ComputerAssembly();
        var processAssemblyResults = new ProcessAssemblyResults();

        // act
        processAssemblyResults.GetResult(computerAssembly, _pcBuilder, _computerFactory.CreateBestComputer());

        // assert
        Assert.True(processAssemblyResults.IsSucceed);
        Assert.False(!processAssemblyResults.IsSucceed);
    }

    [Theory]
    [InlineData("1000W DeepCool PQ1000M Gold (R-PQA00M-FA0B-EU)")]
    public void TestBestComputerWithBadPowerUnitSucceedWithComment(string newPowerUnit)
    {
        // arrange
        var computerAssembly = new ComputerAssembly();
        var processAssemblyResults = new ProcessAssemblyResults();
        Specifications specifications = _computerFactory.CreateBestComputer();
        specifications.PowerUnitName = newPowerUnit;

        // act
        processAssemblyResults.GetResult(computerAssembly, _pcBuilder, specifications);

        // assert
        Assert.True(processAssemblyResults.IsSucceedWithComments);
        Assert.False(!processAssemblyResults.IsSucceedWithComments);
    }

    [Theory]
    [InlineData("ID-COOLING SE-213V2")]
    public void TestBestComputerWithBadCoolingSystemSucceedWithNoWarranty(string newCpuCoolingSystem)
    {
        // arrange
        var computerAssembly = new ComputerAssembly();
        var processAssemblyResults = new ProcessAssemblyResults();
        Specifications specifications = _computerFactory.CreateBestComputer();
        specifications.CpuCoolingSystemName = newCpuCoolingSystem;

        // act
        processAssemblyResults.GetResult(computerAssembly, _pcBuilder, specifications);

        // assert
        Assert.True(processAssemblyResults.IsSucceedWithNoWarranty);
        Assert.False(!processAssemblyResults.IsSucceedWithNoWarranty);
    }

    [Theory]
    [InlineData("AMD RYZEN 5 3600 OEM AM4 Matisse")]
    public void TestBestComputerWithWrongCpuFailed(string newCpu)
    {
        // arrange
        var computerAssembly = new ComputerAssembly();
        var processAssemblyResults = new ProcessAssemblyResults();
        Specifications specifications = _computerFactory.CreateBestComputer();
        specifications.HddName = new List<string>();
        specifications.SsdName = new List<string>();
        specifications.CpuName = newCpu;

        // act
        processAssemblyResults.GetResult(computerAssembly, _pcBuilder, specifications);

        // assert
        Assert.True(processAssemblyResults.IsFailed);
        Assert.False(!processAssemblyResults.IsFailed);
    }
}