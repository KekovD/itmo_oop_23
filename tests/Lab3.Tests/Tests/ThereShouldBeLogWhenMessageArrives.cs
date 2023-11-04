using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ExtensionAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public class ThereShouldBeLogWhenMessageArrives
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
                    new MediumImportance(),
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(GetMessageData), MemberType = typeof(ThereShouldBeLogWhenMessageArrives))]
    private void ConditionCheck(IList<object> messageData)
    {
        var messageLogMock = new Mock<ILogger>();

        Message message = MessageBuilder.Builder()
            .WithTitle((string)messageData[0])
            .WithBody((string)messageData[1])
            .WithImportance((IImportanceLevel)messageData[2])
            .Build();

        var addressee = new RenderableAddressee(
            new RenderableIntegration(new Messenger("Messenger")),
            new LowImportance(),
            messageLogMock.Object);
        TopicBase topic = new Topic("Topic", addressee);

        topic.MessageHandling(message);

        messageLogMock.Verify(log => log.Save(It.IsAny<IList<Message>>(), It.IsAny<Message>()), Times.Once());
    }
}