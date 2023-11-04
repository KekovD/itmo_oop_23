﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ExtensionAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public class FilterAddresseeNotMissedLowImportanceMessage
{
    public static IEnumerable<object[]> GetMessageData
    {
        get
        {
            yield return new object[]
            {
                new List<object>
                {
                    "Title",
                    "Body",
                    1,
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(GetMessageData), MemberType = typeof(FilterAddresseeNotMissedLowImportanceMessage))]
    private void ConditionCheck(IList<object> messageData)
    {
        var messageLogMock = new Mock<ILogger>();

        Message message = MessageBuilder.Builder()
            .WithTitle((string)messageData[0])
            .WithBody((string)messageData[1])
            .WithImportance((int)messageData[2])
            .Build();

        const int highImportance = 3;
        var addressee = new LogAddresseeExpansion(
            new RenderableAddressee(
                new RenderableIntegration(new Messenger("Messenger")), highImportance),
            messageLogMock.Object);
        TopicBase topic = Topic.Builder().WithName("Topic").WithAddressee(addressee).Build();

        topic.MessageHandling(message);

        messageLogMock.Verify(log => log.Save(It.IsAny<Message>()), Times.Never());
    }
}