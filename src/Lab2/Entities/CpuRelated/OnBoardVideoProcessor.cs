using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;

public class OnBoardVideoProcessor : IEquatable<OnBoardVideoProcessor>
{
    public OnBoardVideoProcessor(string type)
    {
        type = type ?? throw new ArgumentNullException(nameof(type));
        Type = type.Length > 0 ? type : throw new EmptyTypeException(nameof(type));
    }

    private string Type { get; }

    public bool Equals(OnBoardVideoProcessor? other)
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
        return Equals((OnBoardVideoProcessor)obj);
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode(StringComparison.Ordinal);
    }
}