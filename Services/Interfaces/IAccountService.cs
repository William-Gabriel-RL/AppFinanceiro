﻿using CrossCutting.Dtos.Account;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        AccountReadDto CreateAccount(Guid peopleId, AccountCreateDto account);

        AccountReadDto? GetAccountById(Guid peopleId, Guid id);

        IEnumerable<AccountReadDto> GetAllAccounts(Guid peopleId);

        AccountAndCardReadDto? GetCardsByAccount(Guid accountGuid);

        void UpdateAccountBalance(Guid accountGuid, decimal value);

        AccountBalanceReadDto? GetAccountBalance(Guid accountGuid);
    }
}
