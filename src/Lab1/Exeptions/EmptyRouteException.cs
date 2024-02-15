using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exeptions;

public class EmptyRouteException : Exception
{
    public EmptyRouteException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmptyRouteException() { }

    public EmptyRouteException(string message)
        : base(message)
    {
    }
}