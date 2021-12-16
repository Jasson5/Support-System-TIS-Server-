IF OBJECT_ID('dbo.GetUsersBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetUsersBySemester
GO

CREATE PROCEDURE dbo.GetUsersBySemester
@Code NVARCHAR(MAX),
@Search NVARCHAR(MAX)
AS
	SELECT  u.[Id], u.[FirstName], u.[LastName], u.[Email], u.GivenName, u.IsEnabled, u.Username
	FROM  UserSemesters us, Users u
	WHERE us.SemesterCode=@Code and us.UserId=u.Id and 
	((u.FirstName like '%' + @Search + '%')
	or (u.LastName like '%' + @Search + '%')
	or (u.Email like '%' + @Search + '%'))
GO
