using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class FirstOrDefaultBenchmark
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
            return list.FirstOrDefault() != null;
        }

        [Benchmark(Description = "HashSet")]
        public bool TestSet()
        {
            return set.FirstOrDefault() != null;
        }

        [Benchmark(Description = "Array")]
        public bool TestArray()
        {
            return array.FirstOrDefault() != null;
        }
    }
}