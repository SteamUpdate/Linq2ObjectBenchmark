using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MedianColumn, MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class OfTypeBenchmark
    {
        private List<IEntity> list;
        private HashSet<IEntity> set;
        private IEntity[] array;

        [Params(1000)]
        public int N { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            SetupHelper.GlobalSetup2(N, out list, out set, out array);
        }

        [Benchmark(Description = "List")]
        public List<Entity> TestList()
        {
            return list.OfType<Entity>().ToList();
        }

        [Benchmark(Description = "HashSet")]
        public List<Entity> TestSet()
        {
            return set.OfType<Entity>().ToList();
        }

        [Benchmark(Description = "Array")]
        public List<Entity> TestArray()
        {
            return array.OfType<Entity>().ToList();
        }
    }
}