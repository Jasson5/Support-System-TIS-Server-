using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CalendarRepository : IRepository<Calendar>
    {
        private readonly IdentityDbContext _context;

        public CalendarRepository(IdentityDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Calendar> List
        {
            get
            {
                return _context.Set<Calendar>();
            }
        }

        public Calendar Add(Calendar entity)
        {
            _context.Set<Calendar>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(Calendar entity)
        {
            _context.Set<Calendar>().Remove(entity);
            _context.SaveChanges();
        }

        public Calendar FindById(int id)
        {
            return _context.Set<Calendar>().Find(id);
        }

        public Calendar FindByIdWithIncludeArray<TInclude>(int id, System.Linq.Expressions.Expression<System.Func<Calendar, System.Collections.Generic.ICollection<TInclude>>> includeFunc)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Calendar> ListWithInclude<TInclude>(System.Linq.Expressions.Expression<System.Func<Calendar, TInclude>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Calendar> ListWithIncludeArray<TInclude>(System.Linq.Expressions.Expression<System.Func<Calendar, System.Collections.Generic.ICollection<TInclude>>> includeFunc) where TInclude : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update(Calendar entity)
        {
            var calendar = _context.Set<Calendar>().Find(entity.Id);

            calendar.DayDate = entity.DayDate;
            calendar.DayDescription = entity.DayDescription;
            calendar.DayObservation = entity.DayObservation;
            calendar.Company = entity.Company;

            _context.SaveChanges();
        }
    }
}