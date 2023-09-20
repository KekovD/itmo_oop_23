namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipSpeed;

public interface IIsAtLightSpeed : IStandardVectorVelocity, ILightVectorVelocity
{
    bool AtLightSpeed { get; set; }
}