using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

//Logica de Tarea

namespace Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IHomeworkRepository _homeworkRepository;

        //Contructor del Servicio de tarea
        public HomeworkService(IHomeworkRepository homeworkRepository)
        {
            this._homeworkRepository = homeworkRepository;
        }

        //Añadir una Tarea nueva
        public Homework AddHomework(Homework homework)
        {
            var newHomework = _homeworkRepository.Add(homework);

            return newHomework;
        }

        //Eliminar una Tarea existente
        public void DeleteHomework(int id)
        {
            var homework = _homeworkRepository.FindById(id);

            if (homework != null)
            {
                _homeworkRepository.Delete(homework);
            }
        }

        //Obtiene la Tarea por su ID
        public Homework GeyById(int id)
        {
            return _homeworkRepository.FindById(id);
        }

        //Se lista todas las tareas
        public ICollection<Homework> ListHomeworks()
        {
            var homework = _homeworkRepository.ListHomeworks();

            return homework.ToList();
        }

        //Actualiza una tarea existente
        public void UpdateHomework(Homework homework)
        {
            _homeworkRepository.Update(homework);
        }
    }
}
