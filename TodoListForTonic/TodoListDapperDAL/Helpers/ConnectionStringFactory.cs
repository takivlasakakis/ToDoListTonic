namespace TodoListDapperDAL.Helpers;

public class ConnectionStringFactory
{
	private readonly IOptionsMonitor<DbSettings> _dbSettings;
	public ConnectionStringFactory(IOptionsMonitor<DbSettings> dbSettings)
	{
		_dbSettings = dbSettings;
	}
	public string GetConnectionString()
	{
		return _dbSettings.GetZOConnectionString();
	}
}