IF OBJECT_ID('dbo.GetCompaniesBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCompaniesBySemester
GO

CREATE PROCEDURE dbo.GetCompaniesBySemester
@Code NVARCHAR(MAX)
AS
	SELECT  c.Id, c.DateCreation, c.ShortName, c.LongName, c.Society, c.Address, c.Telephone, c.CmpanyEmail, s.Name, s.Code, u.GivenName, u.Email, uc.Role
	FROM  Companies c
	INNER JOIN Semesters s
		ON c.SemesterCode=s.Code
		WHERE s.Code=@code 
GO
