using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;

public class SocketCpu : IEquatable<SocketCpu>
{
    public SocketCpu(string type)
    {
        type = type ?? throw new ArgumentNullException(nameof(type));
        Type = type;
    }

    private string Type { get; }

    public bool Equals(SocketCpu? other)
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
        return Equals((SocketCpu)obj);
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode(StringComparison.Ordinal);
    }
}