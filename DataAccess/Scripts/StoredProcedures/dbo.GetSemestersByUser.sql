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
	WHERE us.UserId = @UserId
GO