using Application.Application.Administrators;
using Application.Application.Transactions;
using Application.Application.Users;
using Application.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdministratorService>();
        collection.AddScoped<ISignUpService, SignUpService>();
        collection.AddScoped<ITransactionService, TransactionService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        return collection;
    }
}