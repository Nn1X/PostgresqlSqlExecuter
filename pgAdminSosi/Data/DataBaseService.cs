
using DevExpress.Utils;
using Npgsql;
using pgAdminSosi.Reflection.Models;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace pgAdminSosi.Data
{
    public class DataBaseService
    {
        public async Task<List<string>> GetDataBaseTablesAsync(string connectionString)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var script = "SELECT table_name FROM information_schema.tables WHERE table_schema NOT IN ('information_schema','pg_catalog');";

                var command = new NpgsqlCommand(script, connection);
                var reader = await command.ExecuteReaderAsync();


                var tables = new List<string>();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        var value = reader.GetString(0);
                        tables.Add(value);
                    }
                }

                await reader.CloseAsync();

                return tables;
            }
        }

        public async Task<string> GetDataBaseNameAsync(string connectionString)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var script = "SELECT current_database()";

                var command = new NpgsqlCommand(script, connection);
                var name = (await command.ExecuteScalarAsync()).ToString();

                return name;
            }
        }

        public async Task<List<DynamicClass>> ExecuteScriptAsync(string connectionString, string script)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                List<DynamicClass> dynamicClasses = new List<DynamicClass>();

                await connection.OpenAsync();

                var command = new NpgsqlCommand(script, connection);
                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows) 
                {
                    var columns = await reader.GetColumnSchemaAsync();

                    while (await reader.ReadAsync()) 
                    {
                        var fields = new List<Field>();

                        for (int i = 0; i < columns.Count; i++)
                        {
                            var value = reader.GetValue(i);

                            var field = new Field(columns[i].ColumnName, typeof(string), value?.ToString());
                                
                            fields.Add(field);
                        }

                        var obj = new DynamicClass(fields);
                        dynamicClasses.Add(obj);
                    }
                }

                await reader.CloseAsync();

                return dynamicClasses;
            }
        }
    }
}
