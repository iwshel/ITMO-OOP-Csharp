using Models.Transactions;

namespace Application.Contracts.Users;

public interface ITransactionService
{
    Task<IEnumerable<Transaction>> GetAllTransactions();
    Task<IEnumerable<Transaction>> GetAllUserTransactions();
}