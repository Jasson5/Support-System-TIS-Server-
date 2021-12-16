IF OBJECT_ID('dbo.GetOfferBySemester', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetOfferBySemester
GO

CREATE PROCEDURE dbo.GetOfferBySemester
@Code NVARCHAR(MAX)
AS
	SELECT  o.Id, o.DateCreation, o.DateEnd, o.Description, o.DocumentOfferUrl, o.MaxUsers, o.MinUsers, o.SemesterCode
	FROM  Offers o 
	WHERE o.SemesterCode = @Code
GO