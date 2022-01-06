IF OBJECT_ID('dbo.GetCompaniesByKey', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCompaniesByKey
GO

CREATE PROCEDURE dbo.GetCompaniesByKey
@Key NVARCHAR(MAX)
AS
--Obtener informacion de las companias por su clave primaria(ShortName)
	SELECT  *
	FROM  Companies c
	WHERE c.ShortName=@Key
GO