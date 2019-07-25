
create table ToDoItems  (
	id int Identity(1,1),
	label varchar(256),
	completed bit DEFAULT 0
);