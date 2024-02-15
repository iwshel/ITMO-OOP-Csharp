namespace Models.Transactions;

public record Transaction(long UserId, TransactionType TransactionType, long Amount);