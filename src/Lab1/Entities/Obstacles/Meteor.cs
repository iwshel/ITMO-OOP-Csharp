using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Meteor : ObstacleBase
{
    public Meteor()
        : base(AllConstants.MeteorDamage, false)
    {
    }
}