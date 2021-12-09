USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetSemestersByCode', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetSemestersByCode
GO

CREATE PROCEDURE dbo.GetSemestersByCode
@Code NVARCHAR(MAX)
AS
	SELECT  *
	FROM  Semesters s
	WHERE s.Code = @Code
GO