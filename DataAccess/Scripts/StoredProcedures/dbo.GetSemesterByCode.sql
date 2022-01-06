IF OBJECT_ID('dbo.GetSemesterByCode', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetSemesterByCode
GO

CREATE PROCEDURE dbo.GetSemesterByCode
@Code NVARCHAR(MAX)
AS
--Obtener semestre por su codigo
	SELECT  *
	FROM  Semesters s
	WHERE s.Code = @Code
GO