using System.Threading.Tasks;
using Abstractions.Repositories;
using Application.Application.Users;
using Models.Users;
using Moq;
using Presentation.Console.Scenarios.AccountOperations;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTests
{
    private readonly Mock<IUserRepository> _userRepo;
    private readonly UserService _userService;

    public BankTests()
    {
        var currentUserManager = new CurrentUserManager();
        currentUserManager.User = new User(123, 123, 100);
        _userRepo = new Mock<IUserRepository>();
        _userService = new UserService(_userRepo.Object, currentUserManager);
    }

    [Fact]
    public async Task CheckWithdrawSuccess()
    {
        // Arrange
        var withdrawMoneyScenario = new WithdrawMoneyScenario(_userService);
        _userRepo.Setup(x => x.WithdrawMoney(123, 20)).Returns(Task.FromResult(true));

        // Act
        await withdrawMoneyScenario.RunTest(20);

        // Assert
        _userRepo.Verify(x => x.WithdrawMoney(123, 20), Times.Once);
        if (_userService.CurrentUserManager.User is not null)
        {
            Assert.Equal(80, _userService.CurrentUserManager.User.Balance);
        }
    }

    [Fact]
    public async Task CheckWithdrawFail()
    {
        // Arrange
        var withdrawMoneyScenario = new WithdrawMoneyScenario(_userService);
        _userRepo.Setup(x => x.WithdrawMoney(123, 120)).Returns(Task.FromResult<bool>(false));

        // Act
        await withdrawMoneyScenario.RunTest(120);

        // Assert
        _userRepo.Verify(x => x.WithdrawMoney(123, 120), Times.Once);
        if (_userService.CurrentUserManager.User is not null)
        {
            Assert.Equal(100, _userService.CurrentUserManager.User.Balance);
        }
    }

    [Fact]
    public async Task CheckReplenishmentSuccess()
    {
        // Arrange
        var accountReplenishment = new AccountReplenishmentScenario(_userService);

        // Act
        await accountReplenishment.RunTest(50);

        // Assert
        _userRepo.Verify(x => x.TopUp(123, 50), Times.Once);
        if (_userService.CurrentUserManager.User is not null)
        {
            Assert.Equal(150, _userService.CurrentUserManager.User.Balance);
        }
    }
}