using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exeptions;

public class WrongWeightOverallCharacteristicsException : Exception
{
    public WrongWeightOverallCharacteristicsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongWeightOverallCharacteristicsException() { }

    public WrongWeightOverallCharacteristicsException(string message)
        : base(message)
    {
    }
}