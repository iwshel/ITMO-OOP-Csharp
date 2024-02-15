using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ShowFactorys;

public class ShowFactory
{
    public IShow CreateShow(string mode)
    {
        switch (mode)
        {
            case "console":
                return new ConsoleShow();
            default:
                throw new NotSupportedException($"Mode '{mode}' is not supported.");
        }
    }
}