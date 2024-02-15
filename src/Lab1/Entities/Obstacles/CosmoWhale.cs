using Itmo.ObjectOrientedProgramming.Lab1.Exeptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class CosmoWhale : ObstacleBase
{
    public CosmoWhale(int population)
        : base(AllConstants.CosmoWhaleDamage, false)
    {
        if (population <= 0)
        {
            throw new ZeroPopulationOfWhalesException("population of cosmo whales must be positive");
        }

        Population = population;
    }

    public int Population { get; private set; }
}