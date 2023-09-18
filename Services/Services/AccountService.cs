using AutoMapper;
using CrossCutting.Dtos.Account;
using CrossCutting.Dtos.Card;
using Data.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AccountReadDto CreateAccount(Guid peopleId, AccountCreateDto account)
        {
            var accountModel = _mapper.Map<Account>(account);
            accountModel.IdPeople = peopleId;

            _repository.CreateAccount(accountModel);
            return _mapper.Map<AccountReadDto>(accountModel);
        }

        public AccountReadDto? GetAccountById(Guid peopleId, Guid id)
        {
            var account = _repository.GetAccountById(peopleId, id);
            if (account != null)
                return _mapper.Map<AccountReadDto>(account);
            return null;
        }

        public AccountAndCardReadDto? GetCardsByAccount(Guid accountGuid)
        {
            var tupla = _repository.GetCardsByAccount(accountGuid);
            if (tupla.Item2 != null)
            {
                var cards = _mapper.Map<AccountAndCardReadDto>(tupla.Item2);
                if(tupla.Item1 != null)
                    cards.Cards = _mapper.Map<IEnumerable<CardReadDto>>(tupla.Item1);
                return cards;
            }
            return null;
        }

        public IEnumerable<AccountReadDto> GetAllAccounts(Guid peopleId)
        {
            var accounts = _repository.GetAllAccounts(peopleId);
            return _mapper.Map<IEnumerable<AccountReadDto>>(accounts);
        }

        public AccountBalanceReadDto? GetAccountBalance(Guid accountGuid)
        {
            var balance = _repository.GetAccountBalance(accountGuid);
            if (balance != null)
                return _mapper.Map<AccountBalanceReadDto>(balance);
            return null;
        }
    }
}