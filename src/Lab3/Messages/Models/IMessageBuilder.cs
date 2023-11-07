using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IMessageBuilder
{
    Message Build();
}