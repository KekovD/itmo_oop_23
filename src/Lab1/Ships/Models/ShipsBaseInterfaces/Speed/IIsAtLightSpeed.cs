namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.Speed;

public interface IIsAtLightSpeed : IStandardVectorVelocity, ILightVectorVelocity
{
    bool AtLightSpeed { get; set; }
}