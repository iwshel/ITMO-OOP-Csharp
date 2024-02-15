using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Specifications
{
    public string MotherboardName { get; set; } = string.Empty;
    public string CpuName { get; set; } = string.Empty;
    public string CpuCoolingSystemName { get; set; } = string.Empty;
    public IReadOnlyCollection<string> RamName { get; set; } = new List<string>();
    public string? GpuName { get; set; }
    public IReadOnlyCollection<string> SsdName { get; set; } = new List<string>();
    public IReadOnlyCollection<string> HddName { get; set; } = new List<string>();
    public string PcCaseName { get; set; } = string.Empty;
    public string PowerUnitName { get; set; } = string.Empty;
    public string? WiFiAdapterName { get; set; }
}