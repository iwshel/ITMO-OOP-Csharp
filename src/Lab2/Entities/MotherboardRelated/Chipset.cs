using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Profiles;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;

public class Chipset : IEquatable<Chipset>
{
    public Chipset(string name, string? wifiStandard, int memoryFrequency, XmpProfile? xmpProfile, DocpProfile? docpProfile)
    {
        if (xmpProfile is not null && docpProfile is not null)
        {
            throw new TwoProfilesException();
        }

        Name = name;
        WifiStandard = wifiStandard;
        MemoryFrequency = memoryFrequency > 0
            ? memoryFrequency
            : throw new NegativeFrequencyException(nameof(memoryFrequency));
        Xmp = xmpProfile;
        Docp = docpProfile;
    }

    public Chipset()
    {
        Name = string.Empty;
    }

    public string Name { get; }
    public ChipsetBuilder Builder => new ChipsetBuilder();
    public string? WifiStandard { get; }
    public int MemoryFrequency { get; }
    public XmpProfile? Xmp { get; }
    public DocpProfile? Docp { get; }

    public bool Equals(Chipset? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return WifiStandard == other.WifiStandard && MemoryFrequency == other.MemoryFrequency &&
               Equals(Xmp, other.Xmp) && Equals(Docp, other.Docp);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Chipset)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(WifiStandard, MemoryFrequency, Xmp, Docp);
    }
}