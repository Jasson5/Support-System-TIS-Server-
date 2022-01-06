IF OBJECT_ID('dbo.GetAttendanceForUsers', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceForUsers
GO

CREATE PROCEDURE dbo.GetAttendanceForUsers
@ShortName NVARCHAR(MAX),
@UserId INT
AS
--Obtiene Asistencias del usuario en determinada compania
	SELECT att.*, u.GivenName
	FROM  Attendances att,  UsersCompanies uc, Users u
	WHERE uc.UserId = @UserId and uc.ShortName=@ShortName and att.UserId=u.Id
GO