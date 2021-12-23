using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class FinalGradeService : IFinalGradeService
    {
        private readonly IFinalGradeRepository _finalGradeRepository;

        public FinalGradeService(IFinalGradeRepository finalGradeRepository)
        {
            this._finalGradeRepository = finalGradeRepository;
        }

        public ICollection<FinalGrade> ListFinalGrades(string companyName)
        {
            return _finalGradeRepository.ListFinalGrade(companyName);
        }

        public void Update(FinalGrade finalGrade)
        {
            _finalGradeRepository.Update(finalGrade);
        }
    }
}
