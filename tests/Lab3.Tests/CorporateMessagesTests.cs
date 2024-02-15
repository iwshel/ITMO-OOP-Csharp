using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorporateMessagesTests
{
    private readonly UserAddressee _userAddressee;
    private readonly Message _message;
    private readonly AddresseeProxy _addresseeProxy;
    private readonly Mock<IAddressee> _mockServiceAddressee;
    private readonly Mock<ILogger> _mockServiceLogger;

    public CorporateMessagesTests()
    {
        _userAddressee = new UserAddressee();
        _message = new Message("Hi", "Den", 1);
        _mockServiceAddressee = new Mock<IAddressee>();
        _addresseeProxy = new AddresseeProxy(_mockServiceAddressee.Object);
        _addresseeProxy.ChangeFilterLevel(2);
        _mockServiceLogger = new Mock<ILogger>();
    }

    [Fact]
    public void TestStatusOfReceivedMessage()
    {
        // arrange
        var topicForUser = new Topic("usual", _userAddressee);

        // act
        topicForUser.SendMessage(_message);
        IList<ReadableMessage> allMesages = _userAddressee.GetAllMessages;

        // assert
        Assert.True(!allMesages[0].IsRead);
        Assert.False(allMesages[0].IsRead);
    }

    [Fact]
    public void TestChangeStatusOfMessage()
    {
        // arrange
        var topicForUser = new Topic("usual", _userAddressee);

        // act
        topicForUser.SendMessage(_message);
        IList<ReadableMessage> allMesages = _userAddressee.GetAllMessages;
        _userAddressee.ReadMessage(0);

        // assert
        Assert.True(allMesages[0].IsRead);
        Assert.False(!allMesages[0].IsRead);
    }

    [Fact]
    public void TestChangeReadedMessageToReaded()
    {
        // arrange
        var topicForUser = new Topic("usual", _userAddressee);

        // act
        topicForUser.SendMessage(_message);
        _userAddressee.ReadMessage(0);

        // act and assert
        Assert.Throws<AlreadyReadedMessageException>(() => _userAddressee.ReadMessage(0));
    }

    [Fact]
    public void TestFilter()
    {
        // arrange
        var topicForProxyUser = new Topic("proxy", _addresseeProxy);

        // act
        topicForProxyUser.SendMessage(_message);

        // act and assert
        _mockServiceAddressee.Verify(x => x.ReceiveMessage(_message), Times.Never);
    }

    [Fact]
    public void TestLog()
    {
        // arrange
        _mockServiceLogger.SetupProperty(x => x.LogStatus, true);
        var userAddresseeWithLog = new AddresseeLogDecorator(_userAddressee);
        userAddresseeWithLog.SetNewLogger(_mockServiceLogger.Object);
        var topicForUserLog = new Topic("log", userAddresseeWithLog);

        // act
        topicForUserLog.SendMessage(_message);

        // assert
        _mockServiceLogger.Verify(x => x.Log(_message), Times.Once);
    }

    [Fact]
    public void TestMessenger()
    {
        // arrange
        Mock<ITelegram> mockServiceTelegram = new();
        var messenger = new AddresseeLogDecorator(new MessengerAddressee(new TelegramAdapter(mockServiceTelegram.Object)));
        _mockServiceLogger.SetupProperty(x => x.LogStatus, true);
        messenger.SetNewLogger(_mockServiceLogger.Object);
        var topicForMessenger = new Topic("messenger", messenger);

        // act
        topicForMessenger.SendMessage(_message);

        // assert
        _mockServiceLogger.Verify(x => x.Log(_message), Times.Once);
    }
}