using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Endpoints de NotaFinal

namespace Support_System_Server_v2.Controllers
{
    [Route("api/final-grade")]
    [ApiController]
    public class FinalGradeController : MainController
    {
        private readonly IFinalGradeService _finalGradeService;

        public FinalGradeController(IFinalGradeService finalGradeService)
        {
            this._finalGradeService = finalGradeService;
        }

        //Get/Obtener notas finales por el nombre corto de la grupo empresa
        [HttpGet]
        [Route("{shortName}")]
        public ActionResult<ICollection<FinalGrade>> Get(string shortName)
        {
            return Ok(_finalGradeService.ListFinalGrades(shortName));
        }

        //Get/Obtener notas finales por el codigo del semestre
        [HttpGet]
        [Route("by-semester/{semester}")]
        public ActionResult<ICollection<FinalGrade>> GetApprovedStudents(string semester)
        {
            return Ok(_finalGradeService.ListApprovedStudents(semester));
        }

        //Patch/Actualizar notas finales por su ID
        [HttpPatch]
        [Route("{id}")]
        public ActionResult<FinalGrade> Update(FinalGrade calendar)
        {
            _finalGradeService.Update(calendar);

            return Ok(calendar);
        }
    }
}
