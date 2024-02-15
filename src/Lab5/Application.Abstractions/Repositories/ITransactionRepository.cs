using Models.Transactions;

namespace Abstractions.Repositories;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactions();
    Task<IEnumerable<Transaction>> GetAllUserTransactions(long userId);
}