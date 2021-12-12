USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetAttendanceByUser', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceByUser
GO

CREATE PROCEDURE dbo.GetAttendanceByUser
@UserId INT
AS
	SELECT att.*
	FROM  Attendances att
	WHERE att.UserId = @UserId
GO
