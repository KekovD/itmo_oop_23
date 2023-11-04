using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ExtensionAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;
using Moq;
using Xunit;
using ILogger = Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models.ILogger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public class SendMessageInMessengerExpectedRender
{
    public static IEnumerable<object[]> GetMessageData
    {
        get
        {
            yield return new object[]
            {
                new List<object>
                {
                    "239",
                    "241",
                    new MediumImportance(),
                },
            };
        }
    }

    private static string GetConsoleOutput()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);
        return sw.ToString().Trim();
    }

    [Theory]
    [MemberData(nameof(GetMessageData), MemberType = typeof(SendMessageInMessengerExpectedRender))]
    private void ConditionCheck(IList<object> messageData)
    {
        var messageLogMock = new Mock<ILogger>();

        Message message = MessageBuilder.Builder()
            .WithTitle((string)messageData[0])
            .WithBody((string)messageData[1])
            .WithImportance((IImportanceLevel)messageData[2])
            .Build();

        var messenger = new Messenger("TestName");
        var addressee = new RenderableAddressee(
            new RenderableIntegration(messenger),
            new LowImportance(),
            messageLogMock.Object);
        TopicBase topic = new Topic("Topic", addressee);

        topic.MessageHandling(message);
        messenger.DrawMessage();

        string expectedOutput = "239\n241";
        string result = messenger.Render();

        Assert.Equal(expectedOutput, result);
        messageLogMock.Verify(log => log.Save(It.IsAny<IList<Message>>(), It.IsAny<Message>()), Times.Once());
    }
}