namespace ES_Auth
{
    using System;
    using Elasticsearch.Net;
    using Serilog;
    using Serilog.Sinks.Elasticsearch;

    class Program
    {
        private static ILogger logger;

        static void Main(string[] args)
        {
            logger = CreateLogger().CreateLogger();
            logger.Information("The {User} has just executed {Action}.", "username", "actionName");
            Console.ReadLine();
        }

        private static LoggerConfiguration CreateLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("https://lon5-26392-0.es.objectrocket.com:36392"))
                {
                    ModifyConnectionSettings = x => x.BasicAuthentication("pvr-es-admin", "hT2d9^%U^ATMj8W7^P2L")
                });
        }
    }
}
