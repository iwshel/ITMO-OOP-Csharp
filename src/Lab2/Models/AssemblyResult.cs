namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract record AssemblyResult
{
    private AssemblyResult() { }

    public sealed record AssemblyFailZeroDrive : AssemblyResult;
    public sealed record AssemblyFailWrongSocket : AssemblyResult;
    public sealed record AssemblyFailNotAvailableCpu : AssemblyResult;
    public sealed record AssemblyFailWrongCoolingSystemSocket : AssemblyResult;
    public sealed record AssemblyFailWrongDdrStandard : AssemblyResult;
    public sealed record AssemblyFailNotEnoughRamSlots : AssemblyResult;
    public sealed record AssemblyFailNotEnoughPciESlots : AssemblyResult;
    public sealed record AssemblyFailNotEnoughSataSlots : AssemblyResult;
    public sealed record AssemblyFailIncorrectSizeGpu : AssemblyResult;
    public sealed record AssemblyFailIncorrectMotherboardFormFactor : AssemblyResult;
    public sealed record AssemblyFailConflictWifi : AssemblyResult;
    public sealed record AssemblyFailVoltageInPowerUnit : AssemblyResult;
    public sealed record AssemblyFailNoVideo : AssemblyResult;
    public sealed record DisclaimerOfWarrantyTdp : AssemblyResult;

    public sealed record Comments(string Comment) : AssemblyResult;

    public sealed record AssemblySuccess : AssemblyResult;
}