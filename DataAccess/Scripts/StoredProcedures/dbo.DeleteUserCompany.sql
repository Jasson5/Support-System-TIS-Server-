IF OBJECT_ID('dbo.DeleteUserCompany', 'P') IS NOT NULL
	DROP PROCEDURE dbo.DeleteUserCompany
GO

CREATE PROCEDURE dbo.DeleteUserCompany
@ShortName NVARCHAR(MAX)
AS
	Select *
	FROM  UsersCompanies
    WHERE ShortName = @ShortName
GO