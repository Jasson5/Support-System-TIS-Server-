USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetUsersByNonSemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetUsersByNonSemester
GO

CREATE PROCEDURE dbo.GetUsersByNonSemester
@Code NVARCHAR(MAX),
@Search NVARCHAR(MAX)
AS
	SELECT  u.[Id], u.[FirstName], u.[LastName], u.[Email]
	FROM  UserSemesters us, UsersCompanies uc, Users u
	WHERE us.SemesterCode=@Code and us.UserId<>uc.UserId and 
	((u.FirstName like '%' + @Search + '%')
	or (u.LastName like '%' + @Search + '%')
	or (u.Email like '%' + @Search + '%'))
GO