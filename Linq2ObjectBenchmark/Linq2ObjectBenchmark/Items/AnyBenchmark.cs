using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class AnyBenchmark
    {
        private List<Entity> list;
        private HashSet<Entity> set;
        private Entity[] array;

        [Params(1000)]
        public int N { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            SetupHelper.GlobalSetup(N, out list, out set, out array);
        }

        [Benchmark(Description = "List")]
        public bool TestList()
        {
            return list.Any();
        }

        [Benchmark(Description = "HashSet")]
        public bool TestSet()
        {
            return set.Any();
        }

        [Benchmark(Description = "Array")]
        public bool TestArray()
        {
            return array.Any();
        }
    }
}