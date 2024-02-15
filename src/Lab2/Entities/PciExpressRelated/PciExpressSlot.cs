using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;

public class PciExpressSlot : IEquatable<PciExpressSlot>
{
    public PciExpressSlot(string type, int amountType)
    {
        type = type ?? throw new ArgumentNullException(nameof(type));
        AmountType = amountType >= 0 ? amountType : throw new NegativeAmountSlotsException(nameof(amountType));
        AvailableAmountType = amountType;
        Type = type;
    }

    public string Type { get; }
    private int AmountType { get; }
    private int AvailableAmountType { get; set; }

    public bool SetNewDevice()
    {
        if (AvailableAmountType > 0)
        {
            AvailableAmountType--;
            return true;
        }

        return false;
    }

    public bool Equals(PciExpressSlot? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Type == other.Type && AmountType == other.AmountType;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PciExpressSlot)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, AmountType);
    }
}