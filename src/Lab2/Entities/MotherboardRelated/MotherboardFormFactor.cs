using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;

public class MotherboardFormFactor : IEquatable<MotherboardFormFactor>
{
    public MotherboardFormFactor(string formFactor)
    {
        formFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        Type = formFactor;
    }

    public string Type { get; }

    public bool Equals(MotherboardFormFactor? other)
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
        return Equals((MotherboardFormFactor)obj);
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode(StringComparison.Ordinal);
    }
}