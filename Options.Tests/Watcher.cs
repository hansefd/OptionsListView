using System.Diagnostics;
using Xunit.Abstractions;

namespace Options.Tests
{
    public class Watcher
    {
        private readonly ITestOutputHelper _output;

        private readonly Stopwatch _watcher;

        public Watcher(ITestOutputHelper output)
        {
            _output = output;
            _watcher = new Stopwatch();
        }

        public void Start()
        {
            _watcher.Start();
        }

        public void Record()
        {
            _watcher.Stop();
            _output.WriteLine($"Method executed in {_watcher.ElapsedMilliseconds} ms");
        }
    }
}