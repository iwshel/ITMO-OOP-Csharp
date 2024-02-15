using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.OverallPc;

public class CpuCoolingSystem : IComponent
{
    public CpuCoolingSystem(string name, int length, int width, IList<SocketCpu> sockets, int maxTdp)
    {
        sockets = sockets ?? throw new ArgumentNullException(nameof(sockets));

        Name = name;
        Length = length > 0 ? length : throw new NegativeLengthException(nameof(length));
        Width = width > 0 ? width : throw new NegativeLengthException(nameof(width));
        CorrectSockets = sockets.Count != 0 ? sockets : throw new EmptyCollectionException(nameof(sockets));
        MaxTdp = maxTdp > 0 ? maxTdp : throw new NegativeTdpException(nameof(maxTdp));
    }

    public CpuCoolingSystem()
    {
        CorrectSockets = new List<SocketCpu>();
        Name = string.Empty;
    }

    public string Name { get; }
    public CpuCoolingSystemBuilder Builder => new CpuCoolingSystemBuilder();
    public int Length { get; }
    public int Width { get; }
    public int MaxTdp { get; }
    private IList<SocketCpu> CorrectSockets { get; }

    public bool IsCorrectSocket(SocketCpu socketCpu)
    {
        return CorrectSockets.Contains(socketCpu);
    }

    public CpuCoolingSystemBuilder Direct(CpuCoolingSystemBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.WithLength(Length);
        builder.WithWidth(Width);
        builder.WithCorrectSockets(CorrectSockets);
        builder.WithMaxTdp(MaxTdp);

        return builder;
    }
}