﻿using Application.Models.Accounts;
using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface ICustomerAccountsRepository
{
    Task<string?> FindAccountPasswordByAccountId(long accountId);
    Task<CustomerAccount?> FindAccountByAccountId(long accountId);
    Task CreateCustomer(User newUser, CustomerAccount newAccount, string hashedPassword);
}