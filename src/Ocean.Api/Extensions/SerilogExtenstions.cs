using Serilog;
using Serilog.Events;
using System;

namespace Ocean.Api.Extensions
{
    public static class SerilogExtenstions
    {

        public static LoggerConfiguration CreateLogConfig(this LoggerConfiguration config, Serilog options)
        {

            string LogFilePath(string LogEvent) => string.Format(options.Path, LogEvent);

            string SerilogOutputTemplate = options?.Template + new string('-', 50);

            var LogEventLevel = GetMinimumLogLevel(options.MinLevel);

            config?.Enrich.FromLogContext()
                               .WriteTo.Console()
                               .MinimumLevel.Is(LogEventLevel)
                               .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Information).WriteTo.File(LogFilePath("Information"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))
                               .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Warning).WriteTo.File(LogFilePath("Warning"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))
                               .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Error).WriteTo.File(LogFilePath("Error"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))
                               .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Fatal).WriteTo.File(LogFilePath("Fatal"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate));

            return config;
        }

        private static LogEventLevel GetMinimumLogLevel(string Default)
        {
            LogEventLevel result = LogEventLevel.Information;
            string text = Default;
            if (!string.IsNullOrWhiteSpace(text) && !Enum.TryParse(text, out result))
            {
                result = LogEventLevel.Information;
            }

            return result;
        }

    }


    public class Serilog
    {
        public string Path { get; set; }

        public string MinLevel { get; set; }

        public string Template { get; set; }
    }
}
