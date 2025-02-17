﻿IF OBJECT_ID('dbo.GetCalendarByDatenCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCalendarByDatenCompany
GO

CREATE PROCEDURE dbo.GetCalendarByDatenCompany
@Date DATETIME,
@ShortName NVARCHAR(MAX)
AS
--Obtener la informacion de calendari filtrado por fecha y compania
	SELECT ca.*
	FROM Calendars ca
	WHERE convert(varchar, ca.DayDate, 101) = @Date and ca.CompanyName = @ShortName
GO

