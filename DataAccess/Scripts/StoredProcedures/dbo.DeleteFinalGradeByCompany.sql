IF OBJECT_ID('dbo.DeleteFinalGradeByCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.DeleteFinalGradeByCompany
GO

CREATE PROCEDURE dbo.DeleteFinalGradeByCompany
@ShortName NVARCHAR(MAX)
AS
	DELETE 
    FROM  FinalGrades	
    WHERE CompanyName = @ShortName
GO