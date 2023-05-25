namespace TodoListDapperDAL.Helpers;

public static class ConfigurationExtensions
{
	public static string GetZOConnectionString(this IOptionsMonitor<DbSettings> dbSettings)
	{
		return $"Data Source={dbSettings.CurrentValue.datasource};Initial Catalog={dbSettings.CurrentValue.initialcatalog};" +
		       $"user id={dbSettings.CurrentValue.userid};password={dbSettings.CurrentValue.password};MultipleActiveResultSets=true;{dbSettings.CurrentValue.keywords}";
	}
}