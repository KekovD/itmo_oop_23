using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class ConsoleOutputStrategy : IOutputStrategy
{
    public void Write(string content) => Console.WriteLine(content);
}