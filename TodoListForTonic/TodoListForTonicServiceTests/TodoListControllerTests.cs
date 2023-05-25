using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TodoListDapperDAL.Repository;
using TodoListForTonicService.Controllers;
using TodoListServiceTests.Utils;

namespace TodoListServiceTests;

[TestClass]
public class TodoListControllerTests
{
	internal Mock<TodoRepositoryMockSetup> _mockTodoListRepository;
	[TestMethod]
	public void SaveTodoItemReturnsToDo()
	{
		DefaultHttpContext httpContext = new DefaultHttpContext();
		ControllerContext controllerContext = new ControllerContext()
		{
			HttpContext = httpContext,
		};

		TodoListController controller = new TodoListController(_mockTodoListRepository.Object, new LoggerFactory())
		{
			ControllerContext = controllerContext,
		};

		ToDoItem saveDoItem = controller.SaveToDoItem(new Guid(), "test text string");
		Assert.IsNotNull(saveDoItem);

	}
}