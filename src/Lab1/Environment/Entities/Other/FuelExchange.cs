using System;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;

public class FuelExchange
{
    public int SaveImpulseFuelPrice { get; private set; }
    public int SaveJumpFuelPrice { get; private set; }
    public int ImpulseFuelPrice()
    {
        if (SaveImpulseFuelPrice != 0)
        {
            return SaveImpulseFuelPrice;
        }

        using var randomNumberGenerator = RandomNumberGenerator.Create();
        byte[] randomNumber = new byte[4];
        randomNumberGenerator.GetBytes(randomNumber);
        SaveImpulseFuelPrice = (BitConverter.ToInt32(randomNumber, 0) % 2) + 10;

        return SaveImpulseFuelPrice;
    }

    public int JumpFuelPrice()
    {
        if (SaveJumpFuelPrice != 0)
        {
            return SaveJumpFuelPrice;
        }

        using var randomNumberGenerator = RandomNumberGenerator.Create();
        byte[] randomNumber = new byte[4];
        randomNumberGenerator.GetBytes(randomNumber);
        SaveJumpFuelPrice = (BitConverter.ToInt32(randomNumber, 0) % 3) + 14;

        return SaveJumpFuelPrice;
    }
}