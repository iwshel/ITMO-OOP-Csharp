namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class ResultOfRoute
{
    public ResultOfRoute()
    {
    }

    public bool IsCorrectEngine { get; set; }
    public double Fuel { get; set; }
    public double Time { get; set; }
    public bool IsEnoughFuelCapacity { get; set; }
    public bool IsShipAndCrewIsDead { get; set; }
    public bool IsOnlyCrewDead { get; set; }
    public bool IsSucceed { get; set; }
}