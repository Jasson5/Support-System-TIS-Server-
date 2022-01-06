IF OBJECT_ID('dbo.DeleteFinalGradeByCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.DeleteFinalGradeByCompany
GO

CREATE PROCEDURE dbo.DeleteFinalGradeByCompany
@ShortName NVARCHAR(MAX)
AS
--Devuleve toda la informacion de las notas finales por el nombre de la compania 
	Select *
    FROM  FinalGrades	
    WHERE CompanyName = @ShortName
GO