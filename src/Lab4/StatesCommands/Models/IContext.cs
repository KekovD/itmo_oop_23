using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IContext
{
    string? Address { get; }
    string? Drive { get; }
    IReadOnlyList<Flag>? Flags { get; }

    void TransitionToOtherState(Command request);
    void TransitionToOtherAddress(Command request);
    bool CheckConnectedMode(string mode);
    string GetAbsoluteAddress(string path);
    string GetUniqueFileName(string directory, string fileName);
    bool ConnectRequest();
    bool DisconnectRequest();
    IStrategy? GetStrategy(string strategyFeatures);
    string GetConnectedMode();
}