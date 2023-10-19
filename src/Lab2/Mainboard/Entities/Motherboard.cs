﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Entities;

public class Motherboard : MotherboardBase
{
    public Motherboard(
        string name,
        SocketBase socket,
        int pciENumber,
        int sataNumber,
        IList<int> memoryFrequencies,
        ExtremeMemoryProfilesBase extremeMemoryProfiles,
        DdrMotherboardBase ddrMotherboard,
        int ramTablesNumber,
        FormFactorMotherboardBase formFactor,
        BiosBase bios)
        : base(
            name,
            socket,
            pciENumber,
            sataNumber,
            memoryFrequencies,
            extremeMemoryProfiles,
            ddrMotherboard,
            ramTablesNumber,
            formFactor,
            bios)
    {
    }

    public override MotherboardBase Clone()
    {
        var memoryFrequenciesList = new List<int>(MemoryFrequencies);

        return new Motherboard(
            (string)Name.Clone(),
            Socket.Clone(),
            PciENumber,
            SataNumber,
            memoryFrequenciesList,
            ExtremeMemoryProfiles.Clone(),
            DdrMotherboard.Clone(),
            RamTablesNumber,
            FormFactor.Clone(),
            Bios.Clone());
    }
}