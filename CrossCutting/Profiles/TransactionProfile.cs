using AutoMapper;
using CrossCutting.Dtos.Transaction;
using Domain.Entities;

namespace CrossCutting.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionReadDto>();
            CreateMap<TransactionCreateDto, Transaction>();
        }
    }
}
