using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerAssembly
{
    private PersonalComputer _personalComputer = new PersonalComputer();
    private IList<AssemblyResult> _results = new List<AssemblyResult>();

    public IList<AssemblyResult> TryAssembly(PcBuilder builder, Specifications specifications)
    {
        var pcDirector = new PcDirector(builder, specifications);
        _personalComputer = pcDirector.Direct();

        _results = builder.Results.ToList();

        if (_personalComputer.PcHdd.Count == 0 && _personalComputer.PcSsd.Count == 0)
        {
            _results.Add(new AssemblyResult.AssemblyFailZeroDrive());
        }

        if (string.IsNullOrEmpty(_personalComputer.PcGpu.Name) && _personalComputer.PcCpu.VideoProcessor is null)
        {
            _results.Add(new AssemblyResult.AssemblyFailNoVideo());
        }

        if (!_personalComputer.CheckTdp())
        {
            _results.Add(new AssemblyResult.DisclaimerOfWarrantyTdp());
        }

        if (!_personalComputer.CheckVoltage())
        {
            _results.Add(new AssemblyResult.Comments("Voltage in power unit is not enough"));
        }

        if (_results.Count == 0)
        {
            _results.Add(new AssemblyResult.AssemblySuccess());
        }

        return _results;
    }

    public PersonalComputer? GetResultComputer()
    {
        if (_results.Count != 0 && _results[0] is AssemblyResult.AssemblySuccess) return _personalComputer;
        return null;
    }
}