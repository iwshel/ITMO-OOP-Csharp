using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CpuBuilder
{
    private int _coresFrequency;
    private int _coresAmount;
    private SocketCpu? _socket;
    private OnBoardVideoProcessor? _videoProcessor;
    private int _memoryFrequency;
    private int _tdp;
    private int _powerConsumption;
    private string? _name;

    public CpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CpuBuilder WithCoresFrequency(int coresFrequency)
    {
        _coresFrequency = coresFrequency;
        return this;
    }

    public CpuBuilder WithCoresAmount(int coresAmount)
    {
        _coresAmount = coresAmount;
        return this;
    }

    public CpuBuilder WithSocket(SocketCpu socketCpu)
    {
        _socket = socketCpu;
        return this;
    }

    public CpuBuilder AddBoardProcessor(OnBoardVideoProcessor videoProcessor)
    {
        _videoProcessor = videoProcessor;
        return this;
    }

    public CpuBuilder WithMemoryFrequency(int memoryFrequency)
    {
        _memoryFrequency = memoryFrequency;
        return this;
    }

    public CpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _coresFrequency,
            _coresAmount,
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _videoProcessor,
            _memoryFrequency,
            _tdp,
            _powerConsumption);
    }
}