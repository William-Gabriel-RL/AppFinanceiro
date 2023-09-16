﻿using Data.Context;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppFinanceiroContext _context;

        public PeopleRepository(AppFinanceiroContext context)
        {
            _context = context;
        }

        public void CreatePeople(People people)
        {
            if (people == null) throw new ArgumentNullException(nameof(people));

            _context.Peoples.Add(people);
            _context.SaveChanges();
        }

        public People? GetPeopleById(Guid id)
        {
            return _context.Peoples.FirstOrDefault(p => p.IdPeople == id);
        }
    }
}
