IF OBJECT_ID('dbo.GetHomeworkByCompanies', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetHomeworkByCompanies
GO

CREATE PROCEDURE dbo.GetHomeworkByCompanies
@ShortName NVARCHAR(MAX)
AS
	SELECT h.*
	FROM  Homeworks h
	WHERE h.CompanyShortName = @ShortName
GO
