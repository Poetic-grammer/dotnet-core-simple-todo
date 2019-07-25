CREATE PROCEDURE [dbo].[AddToDo]
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
