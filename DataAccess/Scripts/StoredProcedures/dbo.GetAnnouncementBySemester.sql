IF OBJECT_ID('dbo.GetAnnouncementBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAnnouncementBySemester
GO

CREATE PROCEDURE dbo.GetAnnouncementBySemester
@Code NVARCHAR(MAX)
AS
--Devuelve toda la informacion de Announcement filtrado por semestre
	SELECT  *
	FROM  Announcements a
	WHERE a.SemesterCode = @Code
GO