USE [multitronics]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[AddComment]
		@WebName = N'white-bread',
		@AuthorName = N'Димон1999',
		@Text = N'Мне в новый год продали прошлогоний))))) Я шутник, канешно, ващее, ору в голосину'

SELECT	'Return Value' = @return_value

GO
