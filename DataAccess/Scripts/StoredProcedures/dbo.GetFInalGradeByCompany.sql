IF OBJECT_ID('dbo.GetFInalGradeByCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetFInalGradeByCompany
GO

CREATE PROCEDURE dbo.GetFInalGradeByCompany
@ShortName NVARCHAR(MAX)
AS
	SELECT f.*
	FROM  FinalGrades f
	WHERE f.CompanyName = @ShortName
GO
