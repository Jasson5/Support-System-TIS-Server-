USE SupportSystemTIS
GO

IF OBJECT_ID('dbo.GetOfferBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetOfferBySemester
GO

CREATE PROCEDURE dbo.GetOfferBySemester
@Code NVARCHAR(MAX)
AS
	SELECT  *
	FROM  Offers o 
	WHERE o.SemesterCode = @Code
GO