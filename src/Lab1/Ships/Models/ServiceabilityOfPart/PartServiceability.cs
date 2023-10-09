namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;

public abstract class PartServiceability
{
    public bool Serviceability { get; private set; } = true;
    protected int Health { get; set; }

    public void SetPartServiceability()
    {
        if (Health <= 0)
        {
            Serviceability = false;
        }
    }

    public void DamagingPart(int damage)
    {
        Health -= damage;
        SetPartServiceability();
    }
}