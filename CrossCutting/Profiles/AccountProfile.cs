using AutoMapper;
using CrossCutting.Dtos.Account;
using Domain.Entities;

namespace CrossCutting.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountReadDto>();
            CreateMap<Account, AccountBalanceReadDto>();
            CreateMap<Account, AccountAndCardReadDto>();
            CreateMap<AccountCreateDto, Account>();
        }
    }
}
