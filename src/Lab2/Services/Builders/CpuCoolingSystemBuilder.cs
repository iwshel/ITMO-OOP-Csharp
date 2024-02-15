using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CpuCoolingSystemBuilder
{
    private int _length;
    private int _width;
    private IList<SocketCpu>? _correctSockets;
    private int _maxTdp;
    private string? _name;

    public CpuCoolingSystemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CpuCoolingSystemBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public CpuCoolingSystemBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public CpuCoolingSystemBuilder WithCorrectSockets(IList<SocketCpu> correctSockets)
    {
        _correctSockets = correctSockets;
        return this;
    }

    public CpuCoolingSystemBuilder WithMaxTdp(int maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public CpuCoolingSystem Build()
    {
        return new CpuCoolingSystem(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _length,
            _width,
            _correctSockets ?? throw new ArgumentNullException(nameof(_correctSockets)),
            _maxTdp);
    }
}