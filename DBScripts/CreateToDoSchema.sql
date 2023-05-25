USE [ToDos]
/****** Add Todos schema if it does not exist ******/
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'ToDos')
BEGIN
	EXEC('CREATE SCHEMA [ToDos]')
END

/****** Add user Items table ******/

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'Todos.Items') AND type in (N'U'))
BEGIN
CREATE TABLE [Todos].[Items](
		[ItemId] UNIQUEIDENTIFIER  NOT NULL,
        [Text] NVARCHAR(200) NULL, 
	)
END