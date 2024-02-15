using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;

public class PowerUnit : IComponent
{
    public PowerUnit(string name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad >= 0 ? peakLoad : throw new NegativePeakLoadException(nameof(peakLoad));
    }

    public PowerUnit()
    {
        Name = string.Empty;
        PeakLoad = 0;
    }

    public string Name { get; }
    public int PeakLoad { get; }
}