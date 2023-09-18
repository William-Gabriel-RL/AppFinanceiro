using AutoMapper;
using CrossCutting.Dtos.Card;
using Domain.Entities;

namespace CrossCutting.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardReadDto>();
            CreateMap<CardCreateDto, Card>();
        }
    }
}
