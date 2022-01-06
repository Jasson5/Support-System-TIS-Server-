IF OBJECT_ID('dbo.GetAttendanceByDatenUser', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceByDatenUser
GO

CREATE PROCEDURE dbo.GetAttendanceByDatenUser
@Date DATETIME,
@UserId INT
AS
--Devuelve toda la informacion de Attendances y el nombre de User, filtrado por el id del usuario y la fecha de la asistencia
	SELECT att.*, u.GivenName
	FROM  Attendances att, Users u
	WHERE att.UserId = @UserId and att.UserId = u.Id and convert(varchar, att.AttendanceDate, 101) = @Date
GO