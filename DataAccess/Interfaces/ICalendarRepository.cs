using System;
using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ICalendarRepository
    {
        Calendar Add(Calendar calendar);
        ICollection<Calendar> ListCalendars(string companyName);
        void Update(Calendar calendar);
        Calendar FindById(int id);
        Calendar FindByDate(DateTime date, string Shortname);
        void Delete(Calendar calendar);
    }
}
