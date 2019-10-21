using ReportPortal.Client.Models;

namespace SeleniumExampleTests.Extensions.seleniumReporter
{
    public class Options
    {
        public LogLevel Level { get; set; } = LogLevel.Trace;

        public Options UseDefaultLevel(LogLevel level)

        {

            Level = level;

            return this;

        }

    }
}
