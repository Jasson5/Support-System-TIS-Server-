using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ICalendarRepository
    {
        Calendar Add(Calendar calendar);
        ICollection<Calendar> ListCalendars(string search);
        void Update(Calendar calendar);
        Calendar FindById(int id);
        void Delete(Calendar calendar);
    }
}
