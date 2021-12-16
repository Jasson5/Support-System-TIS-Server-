IF OBJECT_ID('dbo.GetUsersByNonSemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetUsersByNonSemester
GO

CREATE PROCEDURE dbo.GetUsersByNonSemester
@Code NVARCHAR(MAX),
@Search NVARCHAR(MAX)
AS
	SELECT DISTINCT u.[Id], u.[FirstName], u.[LastName], u.[Email], u.GivenName, u.IsEnabled, u.Username
	FROM  UserSemesters us, UsersCompanies uc, Users u
	WHERE us.SemesterCode=@Code and u.Id <> 1 and u.Id NOT IN (	SELECT  u.[Id]
																		FROM  UsersCompanies uc, Users u
																		WHERE uc.UserId=u.Id) and 
	((u.FirstName like '%' + @Search + '%')
	or (u.LastName like '%' + @Search + '%')
	or (u.Email like '%' + @Search + '%'))
GO