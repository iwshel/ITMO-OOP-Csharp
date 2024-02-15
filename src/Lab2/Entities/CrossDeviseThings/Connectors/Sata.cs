using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CrossDeviseThings.Connectors;

public class Sata
{
    public Sata(int amountOfSlots, SataType type)
    {
        if (amountOfSlots < 0)
        {
            throw new NegativeAmountSlotsException(nameof(amountOfSlots));
        }

        AmountOfSlots = amountOfSlots;
        AvailableAmountOfSlots = amountOfSlots;
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }

    public int AmountOfSlots { get; }
    public SataType Type { get; }
    private int AvailableAmountOfSlots { get; set; }

    public bool SetNewInformationStorageDevice()
    {
        if (AvailableAmountOfSlots > 0)
        {
            AvailableAmountOfSlots--;
            return true;
        }

        return false;
    }
}