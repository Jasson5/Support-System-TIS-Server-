IF OBJECT_ID('dbo.GetHomeworkByCompanies', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetHomeworkByCompanies
GO

CREATE PROCEDURE dbo.GetHomeworkByCompanies
@ShortName NVARCHAR(MAX)
AS
--Obtener Homeworks por medio de la compania
	SELECT h.*
	FROM  Homeworks h
	WHERE h.CompanyShortName = @ShortName
GO
