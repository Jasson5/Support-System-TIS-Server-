USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetAttendanceBySpecificUser', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceBySpecificUser
GO

CREATE PROCEDURE dbo.GetAttendanceBySpecificUser
@ShortName NVARCHAR(MAX),
@Search NVARCHAR(MAX)
AS
	SELECT att.*, u.GivenName
	FROM  Attendances att,  UsersCompanies uc, Users u
	WHERE uc.UserId = u.Id and uc.ShortName=@ShortName and att.UserId=u.Id and((u.FirstName like '%' + @Search + '%')
	or (u.LastName like '%' + @Search + '%')
	or (u.Email like '%' + @Search + '%'))
GO
