using DataAccessLayer;
using NBench;

namespace BusinessLogicLayer.Test
{
    public class WhenPerformanceTestExecutedForUserManager
    {
        private Counter _parseThroughput;
        private string ParseThroughputCounterName = "Test";
        private IUserManager _userManager;
        private IUserDataAccess _userDataAccess;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _parseThroughput = context.GetCounter(ParseThroughputCounterName);
            _userDataAccess = new UserDataAccess();
            _userManager = new UserManager(_userDataAccess);
        }

        [PerfBenchmark(NumberOfIterations = 10, RunMode = RunMode.Throughput,
       TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllUsersFor10Iterations(BenchmarkContext context)
        {
            _userManager.GetAllUsers();
            _parseThroughput.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 100, RunMode = RunMode.Throughput,
      TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllUsersFor100Iterations(BenchmarkContext context)
        {
            _userManager.GetAllUsers();
            _parseThroughput.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput,
      TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("Test")]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        public void BenchMarkTestForGetAllUsersFor500Iterations(BenchmarkContext context)
        {
            _userManager.GetAllUsers();
            _parseThroughput.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            _userDataAccess = null;
            _userManager = null;
            _parseThroughput = null;
        }
    }
}
