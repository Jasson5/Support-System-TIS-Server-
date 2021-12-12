USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetAttendanceByCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceByCompany
GO

CREATE PROCEDURE dbo.GetAttendanceByCompany
@ShortName NVARCHAR(MAX)
AS
	SELECT att.*, u.GivenName
	FROM  Attendances att,  UsersCompanies uc, Users u
	WHERE uc.UserId = u.Id and uc.ShortName=@ShortName and att.UserId=u.Id
GO
