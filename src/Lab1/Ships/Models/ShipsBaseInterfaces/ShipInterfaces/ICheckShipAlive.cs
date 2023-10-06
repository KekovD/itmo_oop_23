﻿namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface ICheckShipAlive : IShipAlive, INoJumpEngine
{
    void SetShipAlive();
}