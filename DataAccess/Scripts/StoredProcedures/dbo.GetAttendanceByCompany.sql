IF OBJECT_ID('dbo.GetAttendanceByCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceByCompany
GO

CREATE PROCEDURE dbo.GetAttendanceByCompany
@ShortName NVARCHAR(MAX)
AS
--Devuelve toda la informacion de Attendance y el nombre del User, filtado por la compañia 
	SELECT att.*, u.GivenName
	FROM  Attendances att,  UsersCompanies uc, Users u
	WHERE uc.UserId = u.Id and uc.ShortName=@ShortName and att.UserId=u.Id
GO
