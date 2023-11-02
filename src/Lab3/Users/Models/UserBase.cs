﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageStatus.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageStatus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public abstract class UserBase : IMessageHandling
{
    private readonly IDictionary<Message, IMessageStatus> _receivedMessages = new Dictionary<Message, IMessageStatus>();

    protected UserBase(string name)
    {
        Name = name;
    }

    public string Name { get; private init; }

    public IMessageHandling MessageHandling(Message message)
    {
        _receivedMessages.Add(message, new UnreadMessageStatus());

        return this;
    }

    public UserBase ReadMessage(Message message)
    {
        if (_receivedMessages.ContainsKey(message))
            _receivedMessages[message] = new ReadMessageStatus();

        return this;
    }
}