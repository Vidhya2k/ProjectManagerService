using DataAccessLayer;
using NBench;

namespace BusinessLogicLayer.Test
{
    public class WhenPerformanceProjectExecutedForProjectManager
    {
        private Counter _parseThroughput;
        private string ParseThroughputCounterName = "Test";
        private IProjectManager _projectManager;
        private IProjectManagerDataAccess _projectDataAccess;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _parseThroughput = context.GetCounter(ParseThroughputCounterName);
            _projectDataAccess = new ProjectManagerDataAccess();
            _projectManager = new ProjectManager(_projectDataAccess);
        }

        [PerfBenchmark(NumberOfIterations = 10, RunMode = RunMode.Throughput,
       TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllProjectsFor10Iterations(BenchmarkContext context)
        {
            _projectManager.GetAllProjects();
            _parseThroughput.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 100, RunMode = RunMode.Throughput,
      TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllProjectsFor100Iterations(BenchmarkContext context)
        {
            _projectManager.GetAllProjects();
            _parseThroughput.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput,
      TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllProjectsFor500Iterations(BenchmarkContext context)
        {
            _projectManager.GetAllProjects();
            _parseThroughput.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            _projectDataAccess = null;
            _projectManager = null;
            _parseThroughput = null;
        }
    }
}
