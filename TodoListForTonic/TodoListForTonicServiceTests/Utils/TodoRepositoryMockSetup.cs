namespace TodoListServiceTests.Utils;

internal class TodoRepositoryMockSetup : ITodoRepository
{
	public ToDoItem? _todoItem;
	public Guid _Guid;
	TodoRepositoryMockSetup()
	{
		_Guid = Guid.NewGuid();
		_todoItem = new ToDoItem()
		{
			ItemId = _Guid,
			Text = "this is test text from the mock setup"
		};
	}

	public ToDoItem Fetch(Guid itemId)
	{
		return _todoItem;
	}

	public ToDoItem Save(Guid itemId, string text)
	{
		_todoItem.Text = text;
		_todoItem.ItemId = itemId;
		return _todoItem;
	}

	public void Delete(Guid itemId)
	{
		_todoItem = null;
	}
}