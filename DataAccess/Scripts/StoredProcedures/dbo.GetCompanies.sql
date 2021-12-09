USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetCompanies', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCompanies
GO

CREATE PROCEDURE dbo.GetCompanies
@status INT
AS
	SELECT  c.Id, c.DateCreation, c.ShortName, c.LongName, c.Society, c.Address, c.Telephone, c.CmpanyEmail, c.CmpanyStatus, c.SemesterCode, u.GivenName, u.Email
	FROM  ((UsersCompanies uc
	INNER JOIN Companies c ON uc.CompanyId = c.Id)
	INNER JOIN Users u ON uc.UserId = u.Id)
	WHERE c.CmpanyStatus=@status
GO

