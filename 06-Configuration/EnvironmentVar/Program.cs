namespace EnvironmentVar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () =>
            {
                var environmentVariables = Environment.GetEnvironmentVariables();
                var result = "Environment Variables:\n";

                foreach (var variable in environmentVariables.Keys)
                {
                    result += $"{variable}: {environmentVariables[variable]}\n";
                }

                return result;
            });

            app.Run();
        }
    }
}
