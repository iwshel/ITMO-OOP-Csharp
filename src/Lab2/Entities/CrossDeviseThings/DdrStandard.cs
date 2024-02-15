using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;

public class DdrStandard : IEquatable<DdrStandard>
{
    public DdrStandard(string ddrStandard)
    {
        ddrStandard = ddrStandard ?? throw new ArgumentNullException(nameof(ddrStandard));
        Type = ddrStandard;
    }

    public string Type { get; }

    public bool Equals(DdrStandard? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DdrStandard)obj);
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode(StringComparison.Ordinal);
    }
}