using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PciExpressRelated;

public class PciExpress
{
    public PciExpress(Collection<PciExpressSlot> slots)
    {
        slots = slots ?? throw new ArgumentNullException(nameof(slots));
        Slots = slots.Count > 0 ? slots : throw new EmptyCollectionOfSlotsException(nameof(slots));
    }

    public PciExpress()
    {
        Slots = new List<PciExpressSlot>();
    }

    public IReadOnlyCollection<PciExpressSlot> Slots { get; }
}