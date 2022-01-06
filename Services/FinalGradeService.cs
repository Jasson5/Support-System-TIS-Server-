using DataAccess.Interfaces;
using DataAccess.Model;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

//Logica de la Nota Final

namespace Services
{
    public class FinalGradeService : IFinalGradeService
    {
        private readonly IFinalGradeRepository _finalGradeRepository;

        //Constructor del servicio de la nota final
        public FinalGradeService(IFinalGradeRepository finalGradeRepository)
        {
            this._finalGradeRepository = finalGradeRepository;
        }

        //Se lista las notas finales de los estudiantes por el codigo del semestre que se requiera
        public ICollection<FinalGradeBySemester> ListApprovedStudents(string semesterCode)
        {
            return _finalGradeRepository.ListFinalGradeBySemester(semesterCode);
        }

        //Se lista las notas finales de los estudiantes por el nombre corto de la grupo empresa
        public ICollection<FinalGrade> ListFinalGrades(string companyName)
        {
            return _finalGradeRepository.ListFinalGrade(companyName);
        }

        //Actualiza las notas finales
        public void Update(FinalGrade finalGrade)
        {
            _finalGradeRepository.Update(finalGrade);
        }
    }
}
