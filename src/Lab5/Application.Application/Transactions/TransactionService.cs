using Abstractions.Repositories;
using Application.Application.Users;
using Application.Contracts.Users;
using Models.Transactions;

namespace Application.Application.Transactions;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public TransactionService(ITransactionRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        return await _repository.GetAllTransactions();
    }

    public async Task<IEnumerable<Transaction>> GetAllUserTransactions()
    {
        if (_currentUserManager.User is not null)
        {
            return await _repository.GetAllUserTransactions(_currentUserManager.User.Id);
        }

        return new List<Transaction>();
    }
}