namespace TodoListDapperDAL.Repository;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;

public class BaseRepository
{
	private readonly string _connectionString;
	protected ILogger _logger;

	protected BaseRepository(ConnectionStringFactory connectionStringFactory, ILoggerFactory loggerFactory)
	{
		_connectionString = connectionStringFactory.GetConnectionString();
		_logger = loggerFactory.CreateLogger(this.GetType().Name);
		_logger.LogInformation("connection info" + _connectionString);
	}

	public T QueryFirstOrDefault<T>(string sql, object? parameters = null)
	{
		using IDbConnection connection = OpenConnection();
		return connection.QueryFirstOrDefault<T>(sql, parameters, commandType: CommandType.StoredProcedure);
	}

	public T ExecuteStoredProcedure<T>(string sql, object parameters = null)
	{
		try
		{
			using (var connection = OpenConnection())
			{
				return connection.QuerySingle<T>(sql, parameters, commandType: CommandType.StoredProcedure);
			}
		}
		catch (Exception e)
		{
			_logger.LogError(e.Message, e);
			throw;
		}
	}

	public IDbConnection OpenConnection()
	{
		try
		{
			SqlConnection connection = new(_connectionString);
			connection.Open();
			return connection;
		}
		catch (Exception e)
		{
			_logger.LogError(e.Message, e);
			throw;
		}
	}
}