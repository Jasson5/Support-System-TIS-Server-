using Authentication.Entities;
using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;

        public SemesterService(ISemesterRepository semesterRepository)
        {
            this._semesterRepository = semesterRepository;
        }

        public Semester AddSemester(Semester semester)
        {
            var newSemester = _semesterRepository.Add(semester);

            return newSemester;
        }

        public Semester FindById(int id)
        {
            return _semesterRepository.FindById(id);
        }

        public ICollection<Semester> ListSemesters()
        {
            var semester = _semesterRepository.List();

            return semester.ToList();
        }
    }
}
