using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CaseBuilder
{
    private string? _name;
    private int _maxLengthGpu;
    private int _maxWidthGpu;
    private IList<MotherboardFormFactor>? _acceptableMotherboardFormFactors;
    private int _length;
    private int _width;
    private int _height;

    public CaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CaseBuilder WithMaxLengthGpu(int maxLengthGpu)
    {
        _maxLengthGpu = maxLengthGpu;
        return this;
    }

    public CaseBuilder WithMaxWidthGpu(int maxWidthGpu)
    {
        _maxWidthGpu = maxWidthGpu;
        return this;
    }

    public CaseBuilder WithAcceptableMotherboardFormFactors(IList<MotherboardFormFactor> acceptableMotherboardFormFactors)
    {
        _acceptableMotherboardFormFactors = acceptableMotherboardFormFactors;
        return this;
    }

    public CaseBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public CaseBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public CaseBuilder WithHeight(int height)
    {
        _height = height;
        return this;
    }

    public PcCase Build()
    {
        return new PcCase(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _maxLengthGpu,
            _maxWidthGpu,
            _acceptableMotherboardFormFactors ?? throw new ArgumentNullException(nameof(_acceptableMotherboardFormFactors)),
            _length,
            _width,
            _height);
    }
}