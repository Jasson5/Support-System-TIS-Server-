IF OBJECT_ID('dbo.GetUserSemestersByIdCode', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetUserSemestersByIdCode
GO

CREATE PROCEDURE dbo.GetUserSemestersByIdCode
@UserId INT,
@Code NVARCHAR(MAX)
AS
--Obtener informacion de la tabla intermedia UserSemester por el codigo e id
	SELECT  *
	FROM  UserSemesters us
	WHERE us.SemesterCode=@Code and us.UserId=@UserId
GO