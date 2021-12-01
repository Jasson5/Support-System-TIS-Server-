using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SemesterService : ISemesterService
    {
        private readonly IRepository<Semester> _semesterRepository;

        public SemesterService(IRepository<Semester> semesterRepository)
        {
            this._semesterRepository = semesterRepository;
        }
        public Semester AddSemester(Semester semester)
        {
            var newSemester = _semesterRepository.Add(semester);

            return newSemester;
        }

        public Semester GeyById(int id)
        {
            return _semesterRepository.FindById(id);
        }

        public ICollection<Semester> ListSemester()
        {
            var semester = _semesterRepository.List;

            return semester.ToList();
        }

        public void UpdateSemester(Semester semester)
        {
            _semesterRepository.Update(semester);
        }
    }

}
