USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetUserSemestersByIdCode', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetUserSemestersByIdCode
GO

CREATE PROCEDURE dbo.GetUserSemestersByIdCode
@UserId INT,
@Code NVARCHAR(MAX)
AS
	SELECT  *
	FROM  UserSemesters us
	WHERE us.SemesterCode=@Code and us.UserId=@UserId
GO