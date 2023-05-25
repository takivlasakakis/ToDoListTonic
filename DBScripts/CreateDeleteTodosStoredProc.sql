USE [ToDos]
GO

CREATE OR ALTER PROCEDURE [ToDos].[deleteTodos]
(
	@itemId UNIQUEIDENTIFIER
)

AS
BEGIN    
    SET NOCOUNT ON;
    DELETE FROM [ToDos].[Items]
	WHERE [ItemId] = @itemId
END
GO
