using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamRelated;

public class RamFormFactor : IEquatable<RamFormFactor>
{
    public RamFormFactor(string formFactor)
    {
        formFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        Type = formFactor;
    }

    public string Type { get; }

    public bool Equals(RamFormFactor? other)
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
        return Equals((RamFormFactor)obj);
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode(StringComparison.Ordinal);
    }
}