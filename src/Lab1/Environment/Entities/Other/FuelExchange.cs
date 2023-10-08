using System;
using System.Security.Cryptography;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;

public class FuelExchange : IFuelExchange
{
    public int ImpulseFuelPrice()
    {
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        byte[] randomNumber = new byte[4];
        randomNumberGenerator.GetBytes(randomNumber);

        return (BitConverter.ToInt32(randomNumber, 0) % 20) + 5;
    }

    public int JumpFuelPrice()
    {
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        byte[] randomNumber = new byte[4];
        randomNumberGenerator.GetBytes(randomNumber);

        return (BitConverter.ToInt32(randomNumber, 0) % 30) + 10;
    }
}