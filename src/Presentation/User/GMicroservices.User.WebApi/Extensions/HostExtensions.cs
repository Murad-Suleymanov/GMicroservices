using Npgsql;

namespace GMicroservices.User.WebApi.Extensions
{
    public static class HostExtensions
    {
        public static ConfigureHostBuilder MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating postresql database");
                    logger.LogInformation(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

                    using (var connection = new NpgsqlConnection
                       (configuration.GetValue<string>("DatabaseSettings:ConnectionString")))
                    {
                        connection.Open();

                        using var command = new NpgsqlCommand
                        {
                            Connection = connection
                        };

                        command.CommandText = "DROP TABLE IF EXISTS User";
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE User(Id SERIAL PRIMARY KEY, 
                                                                FirstName VARCHAR(24) NOT NULL,
                                                                UserName VARCHAR(24) NOT NULL,
                                                                Surname VARCHAR(24) NOT NULL,
                                                                Email TEXT,
                                                                UserType INT)";
                        command.ExecuteNonQuery();

                        logger.LogInformation("Migrated postresql database.");
                    }
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the postresql database");

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                }
            }
            return host;
        }
    }
}
