using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;

public interface ITopic
{
    void SendMessage(Message message);
}