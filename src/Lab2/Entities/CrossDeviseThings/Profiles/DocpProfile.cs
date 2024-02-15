using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Profiles;

public class DocpProfile : IEquatable<DocpProfile>
{
    public DocpProfile(string name, IReadOnlyCollection<int> timings, int voltage, int frequency)
    {
        timings = timings ?? throw new ArgumentNullException(nameof(timings));

        Name = name;
        Timings = timings.Count != 0 ? timings : throw new EmptyCollectionException(nameof(timings));
        Voltage = voltage > 0 ? voltage : throw new NegativeVoltageException(nameof(voltage));
        Frequency = frequency > 0 ? frequency : throw new NegativeFrequencyException(nameof(frequency));
    }

    public DocpProfile()
    {
        Name = string.Empty;
        Timings = new List<int>();
    }

    public string Name { get; }
    public ProfileBuilder Builder => new ProfileBuilder();
    public IReadOnlyCollection<int> Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public ProfileBuilder Direct(ProfileBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithTimings(Timings);
        builder.WithVoltage(Voltage);
        builder.WithFrequency(Frequency);

        return builder;
    }

    public bool Equals(DocpProfile? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Timings.Equals(other.Timings) && Voltage == other.Voltage && Frequency == other.Frequency;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DocpProfile)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Timings, Voltage, Frequency);
    }
}