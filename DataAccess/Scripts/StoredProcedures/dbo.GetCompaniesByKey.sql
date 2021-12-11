USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetCompaniesByKey', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCompaniesByKey
GO

CREATE PROCEDURE dbo.GetCompaniesByKey
@ShortName NVARCHAR(MAX)
AS
	SELECT  *
	FROM  Companies c
	WHERE c.ShortName=@ShortName
GO