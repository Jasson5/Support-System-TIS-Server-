IF OBJECT_ID('dbo.GetUsersinCompanies', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetUsersinCompanies
GO

CREATE PROCEDURE dbo.GetUsersinCompanies
@Code NVARCHAR(MAX),
@UserId INT
AS
	SELECT uc.*
	FROM UsersCompanies uc
	WHERE uc.SemesterCode = @Code and uc.UserId = @UserId
GO