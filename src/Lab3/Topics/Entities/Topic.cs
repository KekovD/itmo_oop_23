using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.LabException;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public class Topic : TopicBase
{
    private Topic(string name, AddresseeBase addressee)
        : base(name, addressee)
    {
    }

    public static ITopicNameBuilder Builder() => new TopicBuilder();

    private class TopicBuilder : ITopicBuilder, ITopicNameBuilder, ITopicAddresseeBuilder
    {
        private string? _name;
        private AddresseeBase? _addressee;

        public ITopicAddresseeBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ITopicBuilder WithAddressee(AddresseeBase addressee)
        {
            _addressee = addressee;
            return this;
        }

        public Topic Build() => new(
            _name ?? throw new BuilderNullException(nameof(TopicBuilder)),
            _addressee ?? throw new BuilderNullException(nameof(TopicBuilder)));
    }
}