GO
USE [TrabajadoresPrueba]
GO
CREATE OR ALTER PROCEDURE [dbo].[pMAINGET_TrabajadoresSelect]
(
	@P_SEXO varchar(1)
) AS
DECLARE @L_QUERY VARCHAR(MAX)
		,@L_WHERE VARCHAR(MAX)
BEGIN
	SET @L_QUERY = N'SELECT 
		t.Id
		,COALESCE(t.Nombres, '''') AS Nombres
		,COALESCE(t.NumeroDocumento, '''') AS NumeroDocumento
		,COALESCE(t.Sexo, '''') AS Sexo
		,COALESCE(t.TipoDocumento, '''') AS TipoDocumento
		,COALESCE(dto.NombreDepartamento, '''') AS Departamento 
		,COALESCE(p.NombreProvincia, '''') AS Provincia
		,COALESCE(di.NombreDistrito, '''') AS Distrito
		FROM Trabajadores t
		INNER JOIN Departamento dto ON t.IdDepartamento = dto.Id
		INNER JOIN Provincia p ON t.IdProvincia = p.Id
		INNER JOIN Distrito di ON t.IdDistrito = di.Id '
	IF @P_SEXO != ''
	BEGIN
		SET @L_WHERE = N' WHERE t.Sexo = ' + @P_SEXO	
	END
	BEGIN TRY
		EXECUTE(@L_QUERY + @L_WHERE)
	END TRY
	BEGIN CATCH
		EXECUTE(@L_QUERY + ' WHERE t.Id IS NULL')
	END CATCH
END