using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;

public class Motherboard : IComponent
{
    public Motherboard(
        string name,
        SocketCpu socket,
        PciExpress pciExpress,
        Sata sata,
        Chipset chipset,
        DdrStandard ddr,
        RamConnector ramConnector,
        MotherboardFormFactor motherboardFormFactor,
        Bios bios)
    {
        Name = name;
        MotherboardSocket = socket ?? throw new ArgumentNullException(nameof(socket));
        MotherboardPciExpress = pciExpress ?? throw new ArgumentNullException(nameof(pciExpress));
        MotherboardSata = sata ?? throw new ArgumentNullException(nameof(sata));
        MotherboardChipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        MotherboardDdrStandard = ddr ?? throw new ArgumentNullException(nameof(ddr));
        MotherboardRamConnector = ramConnector ?? throw new ArgumentNullException(nameof(ramConnector));
        FormFactor = motherboardFormFactor ?? throw new ArgumentNullException(nameof(motherboardFormFactor));
        MotherboardBios = bios ?? throw new ArgumentNullException(nameof(bios));
    }

    public Motherboard()
    {
        Name = string.Empty;
        MotherboardSocket = new SocketCpu(string.Empty);
        MotherboardPciExpress = new PciExpress();
        MotherboardSata = new Sata(0, new SataType(string.Empty));
        MotherboardChipset = new Chipset();
        MotherboardDdrStandard = new DdrStandard(string.Empty);
        MotherboardRamConnector = new RamConnector(0);
        FormFactor = new MotherboardFormFactor(string.Empty);
        MotherboardBios = new Bios();
    }

    public string Name { get; }
    public MotherboardBuilder Builder => new MotherboardBuilder();
    public SocketCpu MotherboardSocket { get; }
    public PciExpress MotherboardPciExpress { get; }
    public Sata MotherboardSata { get; }
    public Chipset MotherboardChipset { get; }
    public DdrStandard MotherboardDdrStandard { get; }
    public RamConnector MotherboardRamConnector { get; }
    public MotherboardFormFactor FormFactor { get; }
    public Bios MotherboardBios { get; }

    public MotherboardBuilder Direct(MotherboardBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithSocketCpu(MotherboardSocket);
        builder.WithPciExpress(MotherboardPciExpress);
        builder.WithSata(MotherboardSata);
        builder.WithChipset(MotherboardChipset);
        builder.WithDdrStandard(MotherboardDdrStandard);
        builder.WithRamConnector(MotherboardRamConnector);
        builder.WithFormFactor(FormFactor);
        builder.WithBios(MotherboardBios);

        return builder;
    }
}