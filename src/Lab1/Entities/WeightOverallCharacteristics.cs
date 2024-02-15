using Itmo.ObjectOrientedProgramming.Lab1.Exeptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class WeightOverallCharacteristics
{
    public WeightOverallCharacteristics(int sizeOfShip)
    {
        if (sizeOfShip != 1 && sizeOfShip != 2 && sizeOfShip != 3)
        {
            throw new WrongWeightOverallCharacteristicsException("weight overall characteristics must equal 1,2 or 3");
        }

        Size = sizeOfShip;
    }

    public int Size { get; private set; }
}