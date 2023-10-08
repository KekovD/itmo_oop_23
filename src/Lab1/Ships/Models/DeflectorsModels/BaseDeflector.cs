using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public class BaseDeflector : PartServiceability, IDeflectorInterface, IPartWeight
{
    public BaseDeflector(bool havePhotons)
    {
        DeflectAntimatterFlares = havePhotons;
        PhotonsHealth = (int)HealthPointsPhotonsDeflector.PhotonsDeflectorBrokenOrBaseHealth;
        if (havePhotons)
        {
            PhotonsHealth = (int)HealthPointsPhotonsDeflector.PhotonsDeflectorsHealth;
            PartWeight += (int)WeightOfDeflector.DeflectorPhotonWeight;
        }
    }

    public bool DeflectAntimatterFlares { get; private set; }
    public int PhotonsHealth { get; private set; }
    public int HealthOfDeflector { get; protected set;  }
    public int PartWeight { get; protected init; }

    public void SetHealthOfDeflector(int newValue)
    {
        HealthOfDeflector = newValue;
        SetPartServiceability();
    }

    public void SetHealthOfPhotonsDeflector(int newValue)
    {
        PhotonsHealth = newValue;
        SetPartServiceability();
    }

    public override void SetPartServiceability()
    {
        if (HealthOfDeflector <= 0)
        {
            Serviceability = false;
        }

        if (PhotonsHealth <= 0)
        {
            DeflectAntimatterFlares = false;
        }
    }
}