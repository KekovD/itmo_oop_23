﻿namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IShipCrew : IKillCrew
{
    bool ShipCrewAlive { get; }
}