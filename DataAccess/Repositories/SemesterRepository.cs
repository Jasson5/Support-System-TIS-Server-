﻿using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class SemesterRepository : IRepository<Semester>
    {
        private readonly IdentityDbContext _context;

        public SemesterRepository(IdentityDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Semester> List
        {
            get
            {
                return _context.Set<Semester>();
            }
        }

        public Semester Add(Semester entity)
        {
            _context.Set<Semester>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Semester entity)
        {
            throw new System.NotImplementedException();
        }

        public Semester FindById(int id)
        {
            return _context.Set<Semester>().Find(id);
        }

        public Semester FindByIdWithIncludeArray<TInclude>(int id, System.Linq.Expressions.Expression<System.Func<Semester, System.Collections.Generic.ICollection<TInclude>>> includeFunc)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Semester> ListWithInclude<TInclude>(System.Linq.Expressions.Expression<System.Func<Semester, TInclude>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Semester> ListWithIncludeArray<TInclude>(System.Linq.Expressions.Expression<System.Func<Semester, System.Collections.Generic.ICollection<TInclude>>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update(Semester entity)
        {
            var matter = _context.Set<Semester>().Find(entity.Id);

            matter.NameSemester = entity.NameSemester;
            matter.CodeSemester = entity.CodeSemester;

            _context.SaveChanges();
        }
    }

}
