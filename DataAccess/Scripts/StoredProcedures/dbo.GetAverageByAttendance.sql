IF OBJECT_ID('dbo.GetAverageByAttendance', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAverageByAttendance
GO

CREATE PROCEDURE dbo.GetAverageByAttendance
@ShortName NVARCHAR(MAX)
AS
	SELECT AVG(ALL att.AttendanceGrade) as [GradeAverage], u.GivenName
	FROM  Attendances att,  UsersCompanies uc, Users u
	WHERE uc.UserId = u.Id and uc.ShortName=@ShortName and att.UserId=u.Id
	GROUP BY (u.GivenName)
GO