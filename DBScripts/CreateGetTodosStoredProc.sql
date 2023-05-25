USE [ToDos]
GO

--- =============================================
--- Author: Taki Vlasakakis
--- Create date: 05/09/2023
--- Description: Returns the data a ToDo Item
--- =============================================

CREATE OR ALTER  PROCEDURE [ToDos].[getItems] 
(
    @ItemId UNIQUEIDENTIFIER
)

AS
BEGIN
	SET NOCOUNT ON;

    SELECT
        I.[Text]
    FROM [Todos].[Items] I
    WHERE I.[ItemId] = @ItemId
END