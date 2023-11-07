using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public class MessageIsReceivedByUserItIsSavedNotReadStatus
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
                    3,
                },
            };
        }
    }

    private static bool CheckSendMessageResults(UserBase user, Message message)
    {
        return !user.CheckMessageStatus(message);
    }

    [Theory]
    [MemberData(nameof(GetMessageData), MemberType = typeof(MessageIsReceivedByUserItIsSavedNotReadStatus))]
    private void ConditionCheck(IList<object> messageData)
    {
        Message message = MessageBuilder.Builder()
            .WithTitle((string)messageData[0])
            .WithBody((string)messageData[1])
            .WithImportance((int)messageData[2])
            .Build();

        const int lowImportance = 1;
        UserBase user = new User("User");
        IAddresseeType userAddressee = new UserAddressee(user, lowImportance);
        TopicBase topic = Topic.Builder().WithName("Topic").WithAddressee(userAddressee).Build();
        topic.MessageHandling(message);

        Assert.True(CheckSendMessageResults(user, message));
    }
}