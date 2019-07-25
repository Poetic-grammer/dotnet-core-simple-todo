CREATE PROCEDURE [dbo].[DeleteToDo]
	@targetId int,
	@numDeleted int = -1 output
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
