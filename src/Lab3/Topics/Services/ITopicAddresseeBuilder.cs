using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Services;

public interface ITopicAddresseeBuilder
{
    ITopicBuilder WithAddressee(AddresseeBase addressee);
}