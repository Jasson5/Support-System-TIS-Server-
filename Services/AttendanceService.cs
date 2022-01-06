using DataAccess.Interfaces;
using DataAccess.Model;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

//Logica de Asistencia

namespace Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        //Constructor del Servicio de Asistencia
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            this._attendanceRepository = attendanceRepository;
        }

        //Añadir una Asistencia nueva
        public Attendance AddAttendance(Attendance attendance)
        {
            //Creación de nueva Asistencia que se hara por fecha y Usuario, se controla que no pueda existir dobles asistencias de una persona en una misma fecha.
            var result = _attendanceRepository.FindByDate(attendance.AttendanceDate, attendance.User.Id);
            var newAttendance = new Attendance();
            if (result == null)
            {
                newAttendance = _attendanceRepository.Add(attendance);
            }
            else
            {
                throw new ApplicationException("La asistencia en la fecha dada ya existe");
            }

            return newAttendance;
        }

        //Eliminar una Asistencia
        public void DeleteAttendance(int id)
        {
            var attendance = _attendanceRepository.FindById(id);

            if (attendance != null)
            {
                _attendanceRepository.Delete(attendance);
            }
        }

        //Obtener una asistencia por el ID
        public Attendance GeyById(int id)
        {
            return _attendanceRepository.FindById(id);
        }

        //Listar las asistencias en general
        public ICollection<Attendance> ListAttendances()
        {
            var attendance = _attendanceRepository.ListAttendances();

            return attendance.ToList();
        }

        //Listar las asistencias por el nombre corto de la GrupoEmpresa
        public ICollection<Attendance> ListAttendancesByCompany(string shortName)
        {
            var attendance = _attendanceRepository.ListAttendancesByCompany(shortName);

            return attendance.ToList();
        }

        //Listar las notas de asistencia por el nombre corto de la compañia
        public ICollection<GradeAverageVM> ListGradesByCompany(string companyName)
        {
            var attendance = _attendanceRepository.ListGradesByCompany(companyName);

            return attendance.ToList();
        }

        //Actualizar una asistencia
        public void UpdateAttendance(Attendance attendance)
        {
            _attendanceRepository.Update(attendance);
        }
    }
}
