IF OBJECT_ID('dbo.GetSemestersByUser', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetSemestersByUser
GO

CREATE PROCEDURE dbo.GetSemestersByUser
@UserId INT
AS
--Obtener semester por el id de un usuario 
	SELECT  s.Code, s.DateCreation, s.Name, s.StatusId
	FROM  UserSemesters us, Semesters s
	WHERE us.UserId = @UserId and us.SemesterCode=s.Code
GO
