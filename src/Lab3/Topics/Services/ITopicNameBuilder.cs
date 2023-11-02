namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Services;

public interface ITopicNameBuilder
{
    ITopicAddresseeBuilder WithName(string name);
}