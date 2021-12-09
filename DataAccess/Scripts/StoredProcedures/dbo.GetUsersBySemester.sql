USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetUsersBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetUsersBySemester
GO

CREATE PROCEDURE dbo.GetUsersBySemester
@Code NVARCHAR(MAX)
AS
	SELECT  u.Id, u.FirstName, u.LastName, u.Email
	FROM  UserSemesters us, Users u
	WHERE us.SemesterCode=@Code and us.UserId=u.Id
GO