using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoListDapperDAL.Interfaces;
using TodoListDapperDAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoListForTonicService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : ControllerBase
{
	private readonly ITodoRepository _todoRepository;
	private readonly ILogger _logger;

	public TodoListController(ITodoRepository todoRepository, ILoggerFactory logger)
	{
		_todoRepository = todoRepository;
		_logger = logger.CreateLogger(nameof(TodoListController));
	}

	[HttpGet]
	public IEnumerable<string> GetAll()
	{
		// I haven't implemented this yet, this challenge is taking long enough
		throw new NotImplementedException();
	}

	// GET api/<ValuesController>/5
	[HttpGet("{id}")]
	public ToDoItem Get(Guid id)
	{
		try
		{
			_logger.LogDebug("Get Todo action in TodoController called");
			if (id == null)
			{
				Response.StatusCode = (int)HttpStatusCode.NotFound;
				return null;
			}
			return _todoRepository.Fetch(id);
		}
		catch (Exception ex)
		{
			_logger.LogError($"Failed to get data: {ex.Message}", ex);
			throw new Exception($"Failed to get data: {ex.Message}", ex);
		}

	}

	// PUT api/<ValuesController>/5
	[HttpPut("{id}")]
	public ToDoItem SaveToDoItem(Guid id, [FromBody] string text)
	{
		try
		{
			_logger.LogDebug("Save TodoItem action called in TodoListController");
			if (string.IsNullOrWhiteSpace(id.ToString()))
			{
				_logger.LogInformation("Request is missing ID");
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}
			return _todoRepository.Save(id, text);
		}
		catch (Exception ex)
		{
			_logger.LogError($"Failed to save data: {ex.Message}", ex);
			throw new Exception($"Failed to save data: {ex.Message}", ex);
		}
	}

	// DELETE api/<ValuesController>/5
	[HttpDelete("{id}")]
	public void Delete(Guid id)
	{
		try
		{
			_logger.LogDebug("Delete TodoItem action called in TodoListController");
			if (string.IsNullOrWhiteSpace(id.ToString()))
			{
				_logger.LogInformation("Request is missing ID");
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
			}

			_todoRepository.Delete(id);
		}
		catch (Exception ex)
		{
			_logger.LogError($"Failed to delete data: {ex.Message}", ex);
			throw new Exception($"Failed to delete data: {ex.Message}", ex);
		}
	}
}