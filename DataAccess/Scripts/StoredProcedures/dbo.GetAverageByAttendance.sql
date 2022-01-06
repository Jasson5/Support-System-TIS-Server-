IF OBJECT_ID('dbo.GetAverageByAttendance', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAverageByAttendance
GO

CREATE PROCEDURE dbo.GetAverageByAttendance
@ShortName NVARCHAR(MAX)
AS
--Obtiene el promedio total de todas las asistencias de un usario y su id, filtrado por compania
	SELECT AVG(ALL att.AttendanceGrade) as [GradeAverage], u.Id, 
		sum(case when att.AttendanceStatus = 1 then 1 else 0 end)Presentes, 
		sum(case when att.AttendanceStatus = 2 then 1 else 0 end)Tardes,
		sum(case when att.AttendanceStatus = 3 then 1 else 0 end)Inasistencias
	FROM  Attendances att,  UsersCompanies uc, Users u
	WHERE uc.UserId = u.Id and uc.ShortName=@ShortName and att.UserId=u.Id
	GROUP BY (u.Id)
GO