using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardRelated;

public class RamConnector : IEquatable<RamConnector>
{
    public RamConnector(int amountOfRamSlots)
    {
        if (amountOfRamSlots < 0)
        {
            throw new NegativeAmountSlotsException(nameof(amountOfRamSlots));
        }

        AmountOfRamSlots = amountOfRamSlots;
        AvailableRamSlots = amountOfRamSlots;
    }

    public int AmountOfRamSlots { get; }
    private int AvailableRamSlots { get; set; }

    public bool ConnectNewRam()
    {
        if (AvailableRamSlots > 0)
        {
            AvailableRamSlots--;
            return true;
        }

        return false;
    }

    public bool Equals(RamConnector? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return AmountOfRamSlots == other.AmountOfRamSlots && AvailableRamSlots == other.AvailableRamSlots;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((RamConnector)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AmountOfRamSlots, AvailableRamSlots);
    }
}