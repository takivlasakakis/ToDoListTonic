namespace TodoListDapperDAL.Interfaces;

public interface ITodoRepository
{
	ToDoItem Save(Guid itemId, string text);

	ToDoItem Fetch(Guid itemId);

	void Delete(Guid itemId);
	
}