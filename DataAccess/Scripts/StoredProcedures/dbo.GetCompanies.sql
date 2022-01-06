IF OBJECT_ID('dbo.GetCompanies', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCompanies
GO

CREATE PROCEDURE dbo.GetCompanies
@status INT
AS
--Obtener informacion de compania, el semestre y usuarios filtrado por CmpanyStatus 
	SELECT  c.Id, c.DateCreation, c.ShortName, c.LongName, c.Society, c.Address, c.Telephone, c.CmpanyEmail, s.Name, s.Code, u.GivenName, u.Email, uc.Role, u.Id AS UserId, u.FirstName, u.LastName
	FROM  ((UsersCompanies uc
	INNER JOIN Companies c ON uc.ShortName = c.ShortName)
	INNER JOIN Users u ON uc.UserId = u.Id)
	LEFT JOIN Semesters s ON s.Code = c.SemesterCode
	WHERE c.CmpanyStatus=@status
GO

