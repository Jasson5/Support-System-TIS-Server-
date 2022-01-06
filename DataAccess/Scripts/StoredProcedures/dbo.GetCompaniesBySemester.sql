
IF OBJECT_ID('dbo.GetCompaniesBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCompaniesBySemester
GO

CREATE PROCEDURE dbo.GetCompaniesBySemester
@Code NVARCHAR(MAX)
AS
--Obetner informacion de Compania, semestre y usuario filtrado por semestre 
	SELECT  c.Id, c.DateCreation, c.ShortName, c.LongName, c.Society, c.Address, c.Telephone, c.CmpanyEmail, s.Name, s.Code, u.GivenName, u.Email, uc.Role, u.Id AS UserId, u.FirstName, u.LastName
	FROM  ((UsersCompanies uc
	INNER JOIN Companies c ON uc.ShortName = c.ShortName)
	INNER JOIN Users u ON uc.UserId = u.Id)
	INNER JOIN Semesters s
		ON c.SemesterCode=s.Code
		WHERE s.Code=@code 
GO
