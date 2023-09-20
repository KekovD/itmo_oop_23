namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.Speed;

public interface ILightVectorVelocity : ILightSpeedCounter
{
    int LightSpeed { get; set; }
}