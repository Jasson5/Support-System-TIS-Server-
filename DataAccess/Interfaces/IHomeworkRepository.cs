using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IHomeworkRepository
    {
        Homework Add(Homework homework);
        ICollection<Homework> ListHomeworks();
        void Update(Homework homework);
        Homework FindById(int id);
        void Delete(Homework homework);
    }
}
