IF OBJECT_ID('dbo.GetFInalGradesBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetFInalGradesBySemester
GO

CREATE PROCEDURE dbo.GetFInalGradesBySemester
@Code NVARCHAR(MAX)
AS
--Obtener notas finales con datos de su respectivo semestre y usario, filtrado por semestre
	SELECT f.Id, f.Grade, u.GivenName, s.Name, c.ShortName
	FROM  FinalGrades f
	LEFT JOIN Companies c ON c.ShortName = f.CompanyName
	LEFT JOIN Users u ON u.Id = f.UserId
	LEFT JOIN Semesters s ON s.Code = c.SemesterCode
	where c.SemesterCode = @Code
GO
