namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityAndWeightPart;

public abstract class PartServiceabilityAndWeight
{
    public int PartWeight { get; protected init; }
    public bool Serviceability { get; private set; } = true;
    protected int Health { get; set; }

    public void SetPartServiceability()
    {
        if (Health <= 0)
            Serviceability = false;
    }

    public void DamagingPart(int damage)
    {
        Health -= damage;
        SetPartServiceability();
    }
}