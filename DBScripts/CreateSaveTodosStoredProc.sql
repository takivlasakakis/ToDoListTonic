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

    IF EXISTS (SELECT 1 FROM [ToDos].[Items] WHERE [ItemId] = @ItemId)
    BEGIN;
        THROW 50001, 'Duplicate Item', 1
    END;

    IF NOT EXISTS (SELECT 1	FROM [ToDos].[Items] WHERE [ItemId] = @ItemId)
    BEGIN
        INSERT INTO [ToDos].[Items]([ItemId], [Text])
        VALUES(@itemId, @itemText)
    END

END