IF OBJECT_ID('dbo.GetAttendanceByDatenUser', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceByDatenUser
GO

CREATE PROCEDURE dbo.GetAttendanceByDatenUser
@Date DATETIME,
@UserId INT
AS
	SELECT att.*, u.GivenName
	FROM  Attendances att, Users u
	WHERE att.UserId = @UserId and att.UserId = u.Id and att.AttendanceDate = @Date
GO