using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuRelated;

public class Cpu : IComponent
{
    public Cpu(
        string name,
        int coresFrequency,
        int coresAmount,
        SocketCpu socketCpu,
        OnBoardVideoProcessor? onBoardVideoProcessor,
        int memoryFrequency,
        int tdp,
        int powerConsumption)
    {
        Name = name;
        CoresFrequency = coresFrequency > 0
            ? coresFrequency
            : throw new NegativeFrequencyException(nameof(coresFrequency));
        CoresAmount = coresAmount > 0 ? coresAmount : throw new NegativeAmountCoresException(nameof(coresAmount));
        Socket = socketCpu ?? throw new ArgumentNullException(nameof(socketCpu));
        VideoProcessor = onBoardVideoProcessor;
        MemoryFrequency = memoryFrequency > 0
            ? memoryFrequency
            : throw new NegativeFrequencyException(nameof(memoryFrequency));
        Tdp = tdp > 0 ? tdp : throw new NegativeTdpException(nameof(tdp));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new NegativePowerConsumptionException(nameof(powerConsumption));
    }

    public Cpu()
    {
        Socket = new SocketCpu(string.Empty);
        Name = string.Empty;
    }

    public string Name { get; }
    public CpuBuilder Builder => new CpuBuilder();
    public int CoresFrequency { get; }
    public int CoresAmount { get; }
    public SocketCpu Socket { get; }
    public OnBoardVideoProcessor? VideoProcessor { get; }
    public int MemoryFrequency { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }

    public CpuBuilder Direct(CpuBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithCoresFrequency(CoresFrequency);
        builder.WithCoresAmount(CoresAmount);
        builder.WithSocket(Socket);
        if (VideoProcessor is not null) builder.AddBoardProcessor(VideoProcessor);
        builder.WithMemoryFrequency(MemoryFrequency);
        builder.WithTdp(Tdp);
        builder.WithPowerConsumption(PowerConsumption);

        return builder;
    }
}