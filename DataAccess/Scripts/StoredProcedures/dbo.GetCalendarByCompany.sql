IF OBJECT_ID('dbo.GetCalendarByCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCalendarByCompany
GO

CREATE PROCEDURE dbo.GetCalendarByCompany
@ShortName NVARCHAR(MAX)
AS
	SELECT ca.*
	FROM  Calendars ca, Companies c
	WHERE c.ShortName=@ShortName and c.ShortName = ca.CompanyName
GO