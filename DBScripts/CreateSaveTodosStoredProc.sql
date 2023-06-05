USE [ToDos]
GO

--- =============================================
--- Author: Taki Vlasakakis
--- Create date: 05/09/2023
--- Description: Saves the data for a ToDo Item
--- =============================================

CREATE OR ALTER  PROCEDURE [ToDos].[saveItems] 
(
    @itemId UNIQUEIDENTIFIER,
    @itemText NVARCHAR(200)
)

AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1	FROM [ToDos].[Items] WHERE [ItemId] = @ItemId)
    BEGIN
        INSERT INTO [ToDos].[Items]([ItemId], [Text])
        VALUES(@itemId, @itemText)
    END

    ELSE
    BEGIN
        UPDATE [ToDos].[Items]
        SET
        Text = @itemText
        WHERE
        ItemId = @itemId
    END

    -- return saved data
    EXEC
    [ToDos].[getItems]
END