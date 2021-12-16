IF OBJECT_ID('dbo.GetAttendanceBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAttendanceBySemester
GO

CREATE PROCEDURE dbo.GetAttendanceBySemester
@Code NVARCHAR(MAX)
AS
	SELECT att.*
	FROM  Attendances att
	WHERE att.SemesterCode = @Code
GO

/*No es util */
