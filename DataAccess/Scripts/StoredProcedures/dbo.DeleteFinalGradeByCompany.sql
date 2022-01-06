IF OBJECT_ID('dbo.DeleteFinalGradeByCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.DeleteFinalGradeByCompany
GO

CREATE PROCEDURE dbo.DeleteFinalGradeByCompany
@ShortName NVARCHAR(MAX)
AS
	Select *
    FROM  FinalGrades	
    WHERE CompanyName = @ShortName
GO