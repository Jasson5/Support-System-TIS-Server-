IF OBJECT_ID('dbo.GetOfferById', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetOfferById
GO

CREATE PROCEDURE dbo.GetOfferById
@Id INT
AS
	SELECT  o.Id, o.DateCreation, o.DateEnd, o.Description, o.DocumentOfferUrl, o.MaxUsers, o.MinUsers, o.SemesterCode
	FROM  Offers o 
	WHERE o.Id = @Id
GO