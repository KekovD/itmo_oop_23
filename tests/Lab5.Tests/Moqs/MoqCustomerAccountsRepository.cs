using System;
using System.Collections.Generic;
using System.Linq;
using Application.Abstractions.Repositories;
using Application.Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class MoqCustomerAccountsRepository : ICustomerAccountsRepository
{
    public IList<CustomerAccount> CustomerAccounts { get; } = new List<CustomerAccount>();

    public string? FindAccountPasswordByAccountId(long accountId) => "0";

    public CustomerAccount? FindAccountByAccountId(long accountId) =>
        CustomerAccounts.FirstOrDefault(account => account.AccountId == accountId);

    public void CreateCustomer(CustomerAccount newAccount, string hashedPassword) =>
        CustomerAccounts.Add(newAccount);

    public void ChangeBalance(CustomerAccount account, decimal newBalance)
    {
        CustomerAccount? customerAccount = FindAccountByAccountId(account.AccountId);

        if (customerAccount is null)
            return;

        CustomerAccounts.Remove(customerAccount);

        CustomerAccounts.Add(customerAccount with { Balance = newBalance });
    }

    public void ChangeAccountStateToClose(CustomerAccount account, DateTime closeDate)
    {
        CustomerAccount? customerAccount = FindAccountByAccountId(account.AccountId);

        if (customerAccount is null)
            return;

        CustomerAccounts.Remove(customerAccount);

        CustomerAccounts.Add(customerAccount with { State = AccountState.Close, CloseDate = closeDate });
    }

    public decimal? FindBalanceByAccountId(long accountId) =>
        CustomerAccounts.FirstOrDefault(account => account.AccountId == accountId)?.Balance;
}