using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Profiles;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamRelated;

public class Ram : IComponent
{
    public Ram(
        string name,
        int amountOfStorage,
        int jedecVoltage,
        IReadOnlyCollection<int> frequency,
        XmpProfile? xmpProfile,
        DocpProfile? docpProfile,
        RamFormFactor formFactor,
        DdrStandard ddrStandard,
        int powerConsumption)
    {
        frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
        if (xmpProfile is not null && docpProfile is not null)
        {
            throw new TwoProfilesException();
        }

        Name = name;
        AmountOfStorage = amountOfStorage > 0
            ? amountOfStorage
            : throw new NegativeAmountOfStorageException(nameof(amountOfStorage));
        JedecVoltage = jedecVoltage > 0
            ? jedecVoltage
            : throw new NegativeVoltageException(nameof(jedecVoltage));
        Frequency = frequency.Count > 0 ? frequency : throw new EmptyCollectionException(nameof(frequency));
        RamXmpProfile = xmpProfile;
        RamDocpProfile = docpProfile;
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        RamDdrStandard = ddrStandard ?? throw new ArgumentNullException(nameof(ddrStandard));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new NegativePowerConsumptionException(nameof(powerConsumption));
    }

    public Ram()
    {
        Name = string.Empty;
        Frequency = new List<int>();
        FormFactor = new RamFormFactor(string.Empty);
        RamDdrStandard = new DdrStandard(string.Empty);
    }

    public string Name { get; }
    public RamBuilder Builder => new RamBuilder();
    public int AmountOfStorage { get; }
    public int JedecVoltage { get; }
    public IReadOnlyCollection<int> Frequency { get; }
    public XmpProfile? RamXmpProfile { get; }
    public DocpProfile? RamDocpProfile { get; }
    public RamFormFactor FormFactor { get; }
    public DdrStandard RamDdrStandard { get; }
    public int PowerConsumption { get; }

    public RamBuilder Direct(RamBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithAmountOfStorage(AmountOfStorage);
        builder.WithJdecVoltage(JedecVoltage);
        builder.WithFrequency(Frequency);
        if (RamXmpProfile is not null) builder.AddXmpProfile(RamXmpProfile);
        if (RamDocpProfile is not null) builder.AddDocpProfile(RamDocpProfile);
        builder.WithFormFactor(FormFactor);
        builder.WithDdrStandard(RamDdrStandard);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}