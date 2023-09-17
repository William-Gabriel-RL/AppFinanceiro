using AutoMapper;
using CrossCutting.Dtos.Account;
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

        public IEnumerable<AccountReadDto> GetAllAccounts(Guid peopleId)
        {
            var accounts = _repository.GetAllAccounts(peopleId);
            return _mapper.Map<IEnumerable<AccountReadDto>>(accounts);
        }
    }
}