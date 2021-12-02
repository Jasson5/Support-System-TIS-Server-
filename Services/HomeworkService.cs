using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IRepository<Homework> _homeworkRepository;

        public HomeworkService(IRepository<Homework> homeworkRepository)
        {
            this._homeworkRepository = homeworkRepository;
        }
        public Homework AddHomework(Homework homework)
        {
            var newHomework = _homeworkRepository.Add(homework);

            return newHomework;
        }

        public void DeleteHomework(int id)
        {
            var homework = _homeworkRepository.FindById(id);

            if (homework != null)
            {
                _homeworkRepository.Delete(homework);
            }
        }


        public Homework GeyById(int id)
        {
            return _homeworkRepository.FindById(id);
        }

        public ICollection<Homework> ListHomeworks()
        {
            var homework = _homeworkRepository.List;

            return homework.ToList();
        }

        public void UpdateHomework(Homework homework)
        {
            _homeworkRepository.Update(homework);
        }
    }
}
