USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetSemestersByUser', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetSemestersByUser
GO

CREATE PROCEDURE dbo.GetSemestersByUser
@UserId INT
AS
	SELECT  s.Code, s.DateCreation, s.Name, s.StatusId
	FROM  UserSemesters us, Semesters s
	WHERE us.UserId = @UserId and us.SemesterCode=s.Code
GO

CREATE PROCEDURE dbo.GetOfferBySemester
@Code NVARCHAR(MAX)
AS
	SELECT  *
	FROM  Offers o 
	WHERE o.Semester=@Code
GO

CREATE PROCEDURE dbo.GetUsersBySemester
@Code NVARCHAR(MAX)
AS
	SELECT  u.Id, u.FirstName, u.LastName, u.Email
	FROM  UserSemesters us, Users u
	WHERE us.SemesterCode=@Code and us.UserId=u.Id
GO