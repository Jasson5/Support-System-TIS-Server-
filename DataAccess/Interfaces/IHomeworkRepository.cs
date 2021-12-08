using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IHomeworkRepository
    {
        Homework Add(Homework homework);
        ICollection<Homework> ListHomeworks(string search);
        void Update(Homework homework);
        Homework FindById(int id);
        Homework FindByTittle(string tittle);
        void Delete(Homework homework);
    }
}
