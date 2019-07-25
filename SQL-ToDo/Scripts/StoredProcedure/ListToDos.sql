CREATE PROCEDURE [dbo].[ListToDos]
	
AS
	SELECT id, label, completed from ToDoItems
RETURN 0
