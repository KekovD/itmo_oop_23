namespace Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

public interface ICheckComponentValid
{
    bool ComponentValid { get; }

    void CheckComponentValid(ICheckComponentValid characteristic);
}