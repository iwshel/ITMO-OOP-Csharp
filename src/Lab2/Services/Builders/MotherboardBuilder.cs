using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class MotherboardBuilder
{
    private SocketCpu? _motherboardSocket;
    private PciExpress? _motherboardPciExpress;
    private Sata? _motherboardSata;
    private Chipset? _motherboardChipset;
    private DdrStandard? _motherboardDdrStandard;
    private RamConnector? _motherboardRamConnector;
    private MotherboardFormFactor? _formFactor;
    private Bios? _motherboardBios;
    private string? _name;

    public MotherboardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public MotherboardBuilder WithSocketCpu(SocketCpu motherboardSocket)
    {
        _motherboardSocket = motherboardSocket;
        return this;
    }

    public MotherboardBuilder WithPciExpress(PciExpress motherboardPciExpress)
    {
        _motherboardPciExpress = motherboardPciExpress;
        return this;
    }

    public MotherboardBuilder WithSata(Sata motherboardSata)
    {
        _motherboardSata = motherboardSata;
        return this;
    }

    public MotherboardBuilder WithChipset(Chipset motherboardChipset)
    {
        _motherboardChipset = motherboardChipset;
        return this;
    }

    public MotherboardBuilder WithDdrStandard(DdrStandard motherboardDdrStandard)
    {
        _motherboardDdrStandard = motherboardDdrStandard;
        return this;
    }

    public MotherboardBuilder WithRamConnector(RamConnector motherboardRamConnector)
    {
        _motherboardRamConnector = motherboardRamConnector;
        return this;
    }

    public MotherboardBuilder WithFormFactor(MotherboardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder WithBios(Bios motherboardBios)
    {
        _motherboardBios = motherboardBios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _motherboardSocket ?? throw new ArgumentNullException(nameof(_motherboardSocket)),
            _motherboardPciExpress ?? throw new ArgumentNullException(nameof(_motherboardPciExpress)),
            _motherboardSata ?? throw new ArgumentNullException(nameof(_motherboardSata)),
            _motherboardChipset ?? throw new ArgumentNullException(nameof(_motherboardChipset)),
            _motherboardDdrStandard ?? throw new ArgumentNullException(nameof(_motherboardDdrStandard)),
            _motherboardRamConnector ?? throw new ArgumentNullException(nameof(_motherboardRamConnector)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _motherboardBios ?? throw new ArgumentNullException(nameof(_motherboardBios)));
    }
}