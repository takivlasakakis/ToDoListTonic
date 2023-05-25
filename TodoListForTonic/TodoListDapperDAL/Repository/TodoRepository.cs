namespace TodoListDapperDAL.Repository;

public class TodoRepository: BaseRepository, ITodoRepository
{
	protected TodoRepository(ConnectionStringFactory connectionStringFactory, ILoggerFactory loggerFactory) : base(connectionStringFactory, loggerFactory)
	{
	}

	public ToDoItem Save(Guid itemId, string text)
	{
		_logger.LogInformation("Call Repository Save");
		object spParams = new
		{
			itemId,
			text
		};
		return ExecuteStoredProcedure<ToDoItem>("Todos.saveItems", spParams);
	}

	public ToDoItem Fetch(Guid itemId)
	{
		_logger.LogInformation($"Call Repository Fetch. Id: {itemId}");
		return QueryFirstOrDefault<ToDoItem>("Todos.getItems", new { itemId });
	}

	public void Delete(Guid itemId)
	{
		ExecuteStoredProcedure<ToDoItem>("Todos.deleteItems", new {itemId});
	}
}