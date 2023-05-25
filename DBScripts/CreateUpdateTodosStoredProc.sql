USE [ToDos]
GO

CREATE OR ALTER  PROCEDURE [ToDos].[updateItems] 
(
    @itemId UNIQUEIDENTIFIER,
    @itemText NVARCHAR(200)
)

AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM [ToDos].[Items] WHERE [ItemId] = @itemId)
    BEGIN
        INSERT INTO [ToDos].[Items]([ItemId], [Text])
        VALUES(@itemId, @itemText)
    END
END
