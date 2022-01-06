using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class GradeAverageVM
    {
        //Clase de apoyo 
        public int Id { get; set; }
        public int GradeAverage { get; set; }
        public int Presentes { get; set; }
        public int Tardes { get; set; }
        public int Inasistencias { get; set; }

    }
}
