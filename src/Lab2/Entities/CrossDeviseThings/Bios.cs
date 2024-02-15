using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;

public class Bios : IEquatable<Bios>
{
    public Bios(string type, string version, IList<Cpu> cpu)
    {
        type = type ?? throw new ArgumentNullException(nameof(type));
        version = version ?? throw new ArgumentNullException(nameof(version));
        cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));

        Type = type.Length > 0 ? type : throw new EmptyTypeException(nameof(type));
        Version = version.Length > 0 ? version : throw new EmptyVersionException(nameof(version));
        AvailableCpu = cpu.Count != 0 ? cpu : throw new EmptyCollectionException(nameof(cpu));
    }

    public Bios()
    {
        Type = string.Empty;
        Version = string.Empty;
        AvailableCpu = new List<Cpu>();
    }

    public string Type { get; }
    public string Version { get; }
    private IList<Cpu> AvailableCpu { get; }

    public bool IsAvailableCpu(Cpu cpu)
    {
        return AvailableCpu.Contains(cpu);
    }

    public BiosBuilder Direct(BiosBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithType(Type);
        builder.WithVersion(Version);
        builder.WithAvailableCpu(AvailableCpu);

        return builder;
    }

    public bool Equals(Bios? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Type == other.Type && Version == other.Version && AvailableCpu.Equals(other.AvailableCpu);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Bios)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Version, AvailableCpu);
    }
}