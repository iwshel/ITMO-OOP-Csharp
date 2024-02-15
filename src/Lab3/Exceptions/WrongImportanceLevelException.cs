using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class WrongImportanceLevelException : Exception
{
    public WrongImportanceLevelException(string message)
        : base(message)
    {
    }

    public WrongImportanceLevelException()
    {
    }

    public WrongImportanceLevelException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}