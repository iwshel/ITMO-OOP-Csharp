using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;

public class PcCase : IComponent
{
    public PcCase(
        string name,
        int maxLengthGpu,
        int maxWidthGpu,
        IList<MotherboardFormFactor> acceptableMotherboardFormFactors,
        int length,
        int width,
        int height)
    {
        acceptableMotherboardFormFactors = acceptableMotherboardFormFactors ??
                                           throw new ArgumentNullException(nameof(acceptableMotherboardFormFactors));

        Name = name;
        MaxLengthGpu = maxLengthGpu > 0 ? maxLengthGpu : throw new NegativeLengthException(nameof(maxLengthGpu));
        MaxWidthGpu = maxWidthGpu > 0 ? maxWidthGpu : throw new NegativeLengthException(nameof(maxWidthGpu));
        AcceptableMotherboardFormFactors = acceptableMotherboardFormFactors.Count > 0
            ? acceptableMotherboardFormFactors
            : throw new EmptyCollectionException(nameof(acceptableMotherboardFormFactors));
        Length = length > 0 ? length : throw new NegativeLengthException(nameof(length));
        Width = width > 0 ? width : throw new NegativeLengthException(nameof(width));
        Height = height > 0 ? height : throw new NegativeLengthException(nameof(height));
    }

    public PcCase()
    {
        Name = string.Empty;
        AcceptableMotherboardFormFactors = new List<MotherboardFormFactor>();
    }

    public string Name { get; }
    public CaseBuilder Builder => new CaseBuilder();
    public int MaxLengthGpu { get; }
    public int MaxWidthGpu { get; }
    public int Length { get; }
    public int Width { get; }
    public int Height { get; }
    private IList<MotherboardFormFactor> AcceptableMotherboardFormFactors { get; }

    public bool IsCorrectFormFactor(MotherboardFormFactor motherboardFormFactor)
    {
        return AcceptableMotherboardFormFactors.Contains(motherboardFormFactor);
    }

    public CaseBuilder Direct(CaseBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithMaxLengthGpu(MaxLengthGpu);
        builder.WithMaxWidthGpu(MaxWidthGpu);
        builder.WithAcceptableMotherboardFormFactors(AcceptableMotherboardFormFactors);
        builder.WithLength(Length);
        builder.WithWidth(Width);
        builder.WithHeight(Height);

        return builder;
    }
}