CREATE PROCEDURE [dbo].[MarkCompleteToDo]
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
