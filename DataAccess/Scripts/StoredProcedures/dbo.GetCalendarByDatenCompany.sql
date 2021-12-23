IF OBJECT_ID('dbo.GetCalendarByDatenCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCalendarByDatenCompany
GO

CREATE PROCEDURE dbo.GetCalendarByDatenCompany
@Date DATETIME,
@ShortName NVARCHAR(MAX)
AS
	SELECT ca.*
	FROM  Attendances att, Calendars ca
	WHERE att.AttendanceDate = @Date and att.AttendanceDate = ca.DayDate and att.CompanyName = @ShortName
GO
