using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class TwoProfilesException : Exception
{
    public TwoProfilesException(string message)
        : base(message)
    {
    }

    public TwoProfilesException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public TwoProfilesException()
    {
    }
}