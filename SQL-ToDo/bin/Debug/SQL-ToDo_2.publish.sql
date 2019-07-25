﻿/*
Deployment script for SQL-ToDo

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SQL-ToDo"
:setvar DefaultFilePrefix "SQL-ToDo"
:setvar DefaultDataPath "C:\Users\Alfe\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\Alfe\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[AddToDo]...';


GO
ALTER PROCEDURE [dbo].[AddToDo]
	@label varchar(256)
AS
	begin try
		declare @idNum int;
		insert into ToDoItems (label)
		values (@label);
	
		set @idNum = SCOPE_IDENTITY();
		select id, label, completed from ToDoItems
		where id = @idNum;
	end try
	begin catch
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;
		set @ErrorMessage = ERROR_MESSAGE();
		set @ErrorSeverity = ERROR_SEVERITY();
		set @ErrorState = ERROR_STATE();

		RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState);

	end catch;
	
RETURN
GO
PRINT N'Altering [dbo].[DeleteToDo]...';


GO
ALTER PROCEDURE [dbo].[DeleteToDo]
	@targetId int,
	@numDeleted int = -1
AS
	begin try
		delete from ToDoItems where id = @targetId;
		set @numDeleted = @@ROWCOUNT
	end try
	begin catch
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;
		select
		@ErrorMessage = ERROR_MESSAGE(),
		@ErrorSeverity = ERROR_SEVERITY(),
		@ErrorState = ERROR_STATE();

		RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState);

	end catch;
	

RETURN @numDeleted
GO
PRINT N'Altering [dbo].[MarkCompleteToDo]...';


GO
ALTER PROCEDURE [dbo].[MarkCompleteToDo]
	@targetId int,
	@numRows int OUTPUT
AS

	begin try
		update ToDoItems
		set completed = 1
		where id = @targetId
		set @numRows = @@ROWCOUNT
	end try
	begin catch
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;
		select
		@ErrorMessage = ERROR_MESSAGE(),
		@ErrorSeverity = ERROR_SEVERITY(),
		@ErrorState = ERROR_STATE();

		RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState);

	end catch;
RETURN 0
GO
PRINT N'Update complete.';


GO