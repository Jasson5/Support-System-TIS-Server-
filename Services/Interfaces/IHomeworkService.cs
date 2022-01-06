using Entities;
using System.Collections;
using System.Collections.Generic;

//Interfaces para el servicio de Tarea.

namespace Services.Interfaces
{
    public interface IHomeworkService
    {
        Homework AddHomework(Homework homework);
        ICollection<Homework> ListHomeworks();
        void DeleteHomework(int id);
        void UpdateHomework(Homework homework);
        Homework GeyById(int id);
    }
}
