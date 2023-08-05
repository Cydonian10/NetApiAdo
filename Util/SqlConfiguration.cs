namespace App_Tareas.Util
{
    public class SqlServerConfiguration
    {
        public string ConnectionString { get; set; }
        public SqlServerConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

    }
}