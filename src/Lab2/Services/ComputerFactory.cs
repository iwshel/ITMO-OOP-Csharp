using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerFactory
{
    public Specifications CreateBestComputer()
    {
        var specifications = new Specifications
        {
            MotherboardName = "Gigabyte Z790 Aorus Elite AX",
            CpuName = "Intel Core i9-13900K",
            CpuCoolingSystemName = "DEEPCOOL AK620 ZERO DARK [R-AK620-BKNNMT-G-1]",
            GpuName = "Gigabyte GeForce RTX 4090 GAMING OC 24GB (GV-N4090GAMING OC-24GD)",
            RamName = new Collection<string>()
                { "32Gb 6000MHz Kingston Fury Beast 2x16Gb KIT CL40 DDR5 (KF560C40BBK2-32)" },
            HddName = new Collection<string>() { "2Tb Seagate Barracuda 5400 rpm (ST2000DM005)" },
            SsdName = new Collection<string>() { "SSD 1Tb Samsung 980 Pro NVMe M.2 (MZ-V8P1T0BW)" },
            PcCaseName = "Be Quiet Pure Base 500DX Black TG BGW37",
            PowerUnitName = "1200W Corsair HX1200i (CP-9020070-EU)",
        };

        return specifications;
    }

    public Specifications CreateOptimalComputer()
    {
        var specifications = new Specifications
        {
            MotherboardName = "MSI MAG Z690 Tomahawk WiFi",
            CpuName = "Intel Core i5 12600K OEM Alder Lake LGA1700",
            CpuCoolingSystemName = "Noctua NH-D15",
            GpuName = "MSI GeForce RTX 3060 Ti GAMING X 8GB LHR",
            RamName = new Collection<string>()
                { "32Gb 3200MHz Kingston Fury Beast Black 2x16Gb KIT CL16 DDR4 (KF432C16BB1K2/32)" },
            HddName = new Collection<string>() { "2Tb Seagate Barracuda (ST2000DM008)" },
            SsdName = new Collection<string>() { "SSD 500Gb Samsung 970 Evo Plus NVMe M.2 (MZ-V7S500BW)" },
            PcCaseName = "AeroCool Aero One Frost Black TG (FROST-G-BK-V1)",
            PowerUnitName = "850W Gigabyte GP-P850GM Gold",
        };

        return specifications;
    }

    public Specifications CreateOfficeComputer()
    {
        var specifications = new Specifications
        {
            MotherboardName = "MSI Pro B660M-P DDR4",
            CpuName = "Intel Core i3-12100F",
            CpuCoolingSystemName = "AeroCool Cylon 4",
            GpuName = "Sapphire Radeon RX 6600 Pulse Gaming 8GB (11310-01-20G)",
            RamName = new Collection<string>()
                { "16Gb 3200MHz Patriot Viper Steel 2x8Gb KIT CL16 DDR4 (PVS416G320C6K)" },
            HddName = new Collection<string>() { "1Tb SATA-III Western Digital Caviar Blue (WD10EZEX)" },
            PcCaseName = "Zalman ZM-T6 Black",
            PowerUnitName = "550W DeepCool Nova DN550",
        };

        return specifications;
    }
}