using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public class BaseDeflector : PartServiceability, IDeflectorInterface, IPartWeight
{
    protected const int DeflectorFirstHealth = 20;
    protected const int DeflectorSecondHealth = 100;
    protected const int DeflectorThirdHealth = 400;
    protected const int DeflectorFirstWeight = 100;
    protected const int DeflectorSecondWeight = 200;
    protected const int DeflectorThirdWeight = 300;
    private const int PhotonsDeflectorBrokenOrBaseHealth = 0;
    private const int PhotonsDeflectorsHealth = 3;
    private const int DeflectorPhotonWeight = 250;
    public BaseDeflector(bool havePhotons)
    {
        DeflectAntimatterFlares = havePhotons;
        PhotonsHealth = PhotonsDeflectorBrokenOrBaseHealth;
        if (havePhotons)
        {
            PhotonsHealth = PhotonsDeflectorsHealth;
            PartWeight += DeflectorPhotonWeight;
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