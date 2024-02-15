using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Route
{
    public Route(IReadOnlyCollection<EnvironmentBase> collection)
    {
        Environments = collection ?? throw new ArgumentNullException(nameof(collection));
    }

    public IReadOnlyCollection<EnvironmentBase> Environments { get; private set; }
}