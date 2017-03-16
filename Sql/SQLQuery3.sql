-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Olexandr Panov
-- Create date: 16.03.2017
-- Description:	Adds a comment for a product
-- =============================================
CREATE PROCEDURE [AddComment]
	-- Add the parameters for the stored procedure here
	@WebName nvarchar(64),
	@AuthorName nvarchar(32),
	@Text nvarchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @ProductId int;
	SELECT TOP(1) @ProductId=[ID] FROM [Product] WHERE @WebName=[WebName];
	INSERT INTO [Comment] ([productID], [AuthorName], [Text]) VALUES (@ProductID, @AuthorName, @Text);
END
GO
