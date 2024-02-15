using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ProcessAssemblyResults
{
    public bool IsSucceed { get; set; }
    public bool IsSucceedWithNoWarranty { get; set; }
    public bool IsSucceedWithComments { get; set; }
    public bool IsFailed { get; set; } = true;

    public string GetResult(ComputerAssembly computerAssembly, PcBuilder builder, Specifications specifications)
    {
        computerAssembly = computerAssembly ?? throw new ArgumentNullException(nameof(computerAssembly));
        IList<AssemblyResult> assemblyResults = computerAssembly.TryAssembly(builder, specifications);
        string result = string.Empty;

        foreach (AssemblyResult curResult in assemblyResults)
        {
            if (curResult is AssemblyResult.AssemblyFailZeroDrive)
            {
                result += "Assembly failed, zero ssd and hdd\n";
            }

            if (curResult is AssemblyResult.AssemblyFailWrongSocket)
            {
                result += "Assembly failed, incorrect socket\n";
            }

            if (curResult is AssemblyResult.AssemblyFailNotAvailableCpu)
            {
                result += "Assembly failed, cpu is not available with this motherboard\n";
            }

            if (curResult is AssemblyResult.AssemblyFailWrongCoolingSystemSocket)
            {
                result += "Assembly failed, wrong cooling system socket\n";
            }

            if (curResult is AssemblyResult.AssemblyFailWrongDdrStandard)
            {
                result += "Assembly failed, wrong ddr standard\n";
            }

            if (curResult is AssemblyResult.AssemblyFailNotEnoughRamSlots)
            {
                result += "Assembly failed, not enough ram slots\n";
            }

            if (curResult is AssemblyResult.AssemblyFailNotEnoughPciESlots)
            {
                result += "Assembly failed, not enough pci express slots\n";
            }

            if (curResult is AssemblyResult.AssemblyFailNotEnoughSataSlots)
            {
                result += "Assembly failed, not enough sata slots\n";
            }

            if (curResult is AssemblyResult.AssemblyFailIncorrectSizeGpu)
            {
                result += "Assembly failed, gpu with incorrect size\n";
            }

            if (curResult is AssemblyResult.AssemblyFailIncorrectMotherboardFormFactor)
            {
                result += "Assembly failed, incorrect motherboard form factor\n";
            }

            if (curResult is AssemblyResult.AssemblyFailConflictWifi)
            {
                result += "Assembly failed, wifi standards are conflicting\n";
            }

            if (curResult is AssemblyResult.AssemblyFailVoltageInPowerUnit)
            {
                result += "Assembly failed, not enough voltage in power unit\n";
            }

            if (curResult is AssemblyResult.AssemblyFailNoVideo)
            {
                result += "Assembly failed, zero video processors\n";
            }

            if (curResult is AssemblyResult.DisclaimerOfWarrantyTdp)
            {
                IsSucceedWithNoWarranty = true;
                IsFailed = false;
                result += "Assembly with no warranty\n";
            }

            if (curResult is AssemblyResult.Comments err)
            {
                IsSucceedWithComments = true;
                result += err.Comment;
            }

            if (curResult is AssemblyResult.AssemblySuccess)
            {
                IsSucceed = true;
                IsFailed = false;
                result += "Assembly succeed\n";
            }
        }

        return result;
    }
}