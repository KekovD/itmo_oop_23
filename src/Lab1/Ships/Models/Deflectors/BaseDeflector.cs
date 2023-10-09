using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public class BaseDeflector : PartServiceability, IPartWeight
{
    protected const int DeflectorFirstHealth = 20;
    protected const int DeflectorSecondHealth = 100;
    protected const int DeflectorThirdHealth = 400;
    protected const int DeflectorFirstWeight = 100;
    protected const int DeflectorSecondWeight = 200;
    protected const int DeflectorThirdWeight = 300;
    private const int PhotonsDeflectorBrokenOrWithoutHealth = 0;
    private const int PhotonsDeflectorsHealth = 3;
    private const int DeflectorPhotonWeight = 250;
    protected BaseDeflector(bool havePhotons)
    {
        DeflectAntimatterFlares = havePhotons;
        PhotonsHealth = PhotonsDeflectorBrokenOrWithoutHealth;
        if (havePhotons)
        {
            PhotonsHealth = PhotonsDeflectorsHealth;
            PartWeight += DeflectorPhotonWeight;
        }
    }

    public bool DeflectAntimatterFlares { get; private set; }
    public int PartWeight { get; protected init; }
    private int PhotonsHealth { get; set; }
    public void DamagingPhotonsDeflector(int damage)
    {
        PhotonsHealth -= damage;
        SetPhotonsServiceability();
    }

    private void SetPhotonsServiceability()
    {
        if (PhotonsHealth <= 0)
        {
            DeflectAntimatterFlares = false;
        }
    }
}